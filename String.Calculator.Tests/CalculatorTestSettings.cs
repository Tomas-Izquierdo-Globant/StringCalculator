using Microsoft.Extensions.Configuration;
using StringCalculator_Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace String.Calculator.Tests
{
    public  class CalculatorTestSettings
    {

        public string[] defaultDelimeters
        {
            get; set; 
        }
        public static  CalculatorSettings Load() 
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

            var settings = new CalculatorSettings();

            config.GetSection("CalculatorSettings").Bind(settings);

            return settings;
        }
    }
}
