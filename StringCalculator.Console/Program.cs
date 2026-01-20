using StringCalculator.Core;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using StringCalculator_Core;
using Microsoft.Extensions.Options;

class program
{
    static void Main(string[] args) {
        var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddCommandLine(args)
                .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true)
                .Build();

       // var calculatorSettings = config.GetSection("CalculatorSettings").Get<CalculatorSetting>();



        var settings = new CalculatorSettings();

        config.GetSection("CalculatorSettings").Bind(settings);

        var options = Options.Create(settings);


        var calculator = new StringCalculator.Core.StringCalculator(options);

        //var result = calculator.add("1,2,3");
        //Console.WriteLine($"Resultado:{result}");


        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (input == null) break;

            Console.WriteLine(calculator.calculate(input));
        }

    }

}

//var calculator = new StringCalculator.Core.StringCalculator();

//Console.WriteLine(calculator.add("1,2,3"));

