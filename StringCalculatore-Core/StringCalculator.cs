using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StringCalculator_Core;
using StringCalculatore_Core;
using System.Text.RegularExpressions;

namespace StringCalculator.Core
{
    public class StringCalculator
    {
        private readonly List<string> _delimeters;
        private readonly int _maxNumber;
        private readonly bool _allowNegativeNumber;
        private readonly CalculatorSettings _settings;
        private readonly string _StartsWith;
        private  string[] _numberStrings;


        public StringCalculator(IOptions<CalculatorSettings> settings)
        {
            _settings = settings.Value;
            _delimeters = new List<string>(_settings.defaultDelimiters);
            _maxNumber = _settings.maxNumber;
            _allowNegativeNumber = _settings.AllowNegativeNumbers;
            _StartsWith = _settings.StartsWith;
        }

        public void addCustomDelimeter(string customDelimeter)
        { 
            if (! string.IsNullOrEmpty(customDelimeter))
                _delimeters.Add(customDelimeter);
        }

        public int calculate(string numbers, OperationType operation = OperationType.Add)
        {


            if (string.IsNullOrWhiteSpace(numbers))
                return operation == OperationType.Multiply ? 1 : 0;


            if (numbers.StartsWith(_StartsWith))
            {

                var parts = numbers.Split('\n',2);

                var customs = parts[0].Substring(2);

                // soporta //[***] o //[*][%]
                var matches = Regex.Matches(customs, @"\[(.*?)\]");

                if (matches.Count > 0)
                {
                    foreach (Match m in matches)
                        addCustomDelimeter(m.Groups[1].Value);
                }
                else
                {
                    // delimitador simple tipo //;
                    addCustomDelimeter(customs);
                }

                numbers = parts.Length > 1 ? parts[1] : "";


            }

            var pattern = string.Join("|", _delimeters
                .OrderByDescending(d=>d.Length)
                .Select(Regex.Escape));

            int result = operation switch
            {
                OperationType.Multiply => 1,
                _ => 0
            };


            var numberStrings = Regex.Split(numbers, pattern);

         
            List<int> negativos = new List<int>();




            foreach (var parte in numberStrings)
            {
                if (int.TryParse(parte, out int numero))
                {
                    if (!_allowNegativeNumber && numero < 0)
                    {
                        negativos.Add(numero);
                    }
                    else if (numero > _maxNumber) continue;


                    switch (operation)
                    {
                        case OperationType.Add:
                            result += numero;
                            break;
                        case OperationType.Subtract:
                            result -= numero;
                            break;
                        case OperationType.Multiply:
                            result *= numero;
                            break;
                        case OperationType.Divide:
                            if (numero != 0) // evitar división por cero
                                result /= numero;
                            break;
                    }


                }

            }

            if (negativos.Any())
            {
                throw new ArgumentException("números negativos no permitidos: " + string.Join(", ", negativos));
            }
            this._numberStrings = numberStrings;
            return result;
        }



        public CalculationResult addWithFormula(string numbers)
        {
            var suma = this.calculate(numbers);
            var numberString = this._numberStrings;

            var usedNumbers = numberString.Select(p => int.TryParse(p, out int n) && n <= _maxNumber ? n : 0).ToList();
            var formula = string.Join("+", usedNumbers);
            var result = usedNumbers.Sum();

            return new CalculationResult($"{formula} = {result}", result);
        }


        public record CalculationResult(string Formula, int Result);

    }
}
