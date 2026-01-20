using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator_Core
{
    public class CalculatorSettings
    {
        public string[] defaultDelimiters { get; set; } = new string[] {",","\n","#","[***]" };
        public int maxNumber { get; set; } = 1000;
        public bool AllowNegativeNumbers { get; set; } = false;

        public int MaxNumbersAllowed { get; set; }
        public string[] Separators { get; set; } = Array.Empty<string>();
        public int SkipNumbersGreaterThan { get; set; }

        public string StartsWith { get; set; }

    }
}
