using System.Text.RegularExpressions;

namespace StringCalculator.Core
{
    public class StringCalculator
    {
        public int add(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
                return 0;

            List<string> delimitadores = new List<string> { ",", "\n" };

            if (input.StartsWith("//"))
            {

                delimitadores.Clear();

                int saltoLinea = input.IndexOf("\n");

                string encabezado = input.Substring(2, saltoLinea - 2);

                var matches = Regex.Matches(encabezado, @"\[(.*?)\]");

                if (matches.Count > 0)
                    foreach (Match match in matches)
                    {
                        delimitadores.Add(match.Groups[1].Value);
                    }
                else
                {
                    delimitadores.Add(encabezado);
                }


                input = input.Substring(saltoLinea + 1);
            }

            string[] partes = input.Split(delimitadores.ToArray(), StringSplitOptions.None);

            int suma = 0;
            List<int> negativos = new List<int>();
            foreach (var parte in partes)
            {
                if (int.TryParse(parte, out int numero))
                {
                    if (numero < 0)
                    {
                        negativos.Add(numero);
                    }
                    else if (numero <= 1000)
                        suma += numero;
                }

            }

            if (negativos.Count > 0)
            {
                throw new ArgumentException("números negativos no permitidos: " + string.Join(", ", negativos));
            }
            return suma;
        }

    }
}
