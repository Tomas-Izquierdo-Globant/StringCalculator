
using Microsoft.Extensions.Options;
using StringCalculator_Core;
using StringCalculatore_Core;
using Xunit.Abstractions;

namespace String.Calculator.Tests
{
    public class StringCalculatorTests
    {
        private string _input = "";
        private int _result = 0;
        private readonly IOptions<CalculatorSettings> _settings;

        public StringCalculatorTests()
        {
            var settings = CalculatorTestSettings.Load();

            _settings = Options.Create(settings);
            _input = "";
            _result = 0;

        }


        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            _input = "";

            //act
            _result = calc.calculate("");

            //assert
            Assert.Equal(0, _result);

        }

        [Fact]
        public void Add_SingleNumber_ReturnsSameNumber()
        {

            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            _input = "20";

            //act
            _result = calc.calculate(_input);

            //assert
            Assert.Equal(20, _result);

        }

        [Fact]
        public void Add_SingleNumber_ReturnsSum()
        {

            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            _input = "998,1";

            //act
            _result = calc.calculate(_input);

            //assert
            Assert.Equal(999, _result);

        }
        [Fact]
        public void Add_SingleNumber_TreatedAsZero()
        {

            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            _input = "5,qwerty";

            //act
            _result = calc.calculate(_input);

            //assert
            Assert.Equal(5, _result);

        }
        [Fact]
        public void Add_MultipleNumbers_ReturnsSum()
        {
            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            _input = "1,2,3,4,5,6,7,8,9,10,11,12";

            //act
            _result = calc.calculate(_input);

            //assert
            Assert.Equal(78, _result);


        }
        [Fact]
        public void AddNewLineDelimeter_ReturnsSum()
        {

            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            _input = "1\n2,3";

            //act
            _result = calc.calculate(_input);

            //assert
            Assert.Equal(6, _result);


        }
        [Fact]
        public void AddNegativeNumbers_ThrowsException()
        {

            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            _input = "2,-4,3,-5";

            //act
            var ex = Assert.Throws<ArgumentException>(() => calc.calculate(_input));

            //assert
            Assert.Contains("-4", ex.Message);
            Assert.Contains("-5", ex.Message);

        }
        [Fact]
        public void Add_NumberGreaterThan1000_Ignored()
        {

            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            _input = "2,1001,6";

            //act
            _result = calc.calculate(_input);

            //assert
            Assert.Equal(8, _result);

        }
        [Fact]
        public void Add_CustomSingleCharDelimeter_Returns_Sum()
        {

            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            var _input1 = "//#\n2#5";
            var _input2 = "//#\n1#2";

            //act
            var _result1 = calc.calculate(_input1);
            var _result2 = calc.calculate(_input2);

            //assert
            Assert.Equal(_result1, calc.calculate(_input1));
            Assert.Equal(_result2, calc.calculate(_input2));
        }
        [Fact]
        public void Add_WhiteSpace_ReturnsZero()
        {

            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            _input = "     ";

            //act
            _result = calc.calculate(_input);

            //assert
            Assert.Equal(0, _result);
        }
        [Fact]
        public void Add_stringVariety_ReturnsSum()
        {
            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            var _input1 = "1,2\n3";
            var _input2 = "2,1001,6";
            var _input3 = "//#\n2#5";
            var _input4 = "//[***]\n11***22***33";
            var _input5 = "//[*][%]\n1*2%3";
            var _input6 = "";

            //act
            var _result1 = calc.calculate(_input1);
            var _result2 = calc.calculate(_input2);
            var _result3 = calc.calculate(_input3);
            var _result4 = calc.calculate(_input4);
            var _result5 = calc.calculate(_input5);
            var _result6 = calc.calculate(_input6);
            var ex = Assert.Throws<ArgumentException>(() => calc.calculate("1,-2,3"));

            //assert
            Assert.Equal(6, _result1);
            Assert.Equal(8, _result2);
            Assert.Equal(7, _result3);
            Assert.Equal(66, _result4);
            Assert.Equal(6, _result5);
            Assert.Equal(0, _result6);
            Assert.Contains("-2", ex.Message);


        }

        public void Add_stringVariety_ReturnsOperation()
        {
            //arrange
            var calc = new StringCalculator.Core.StringCalculator(_settings);
            var _input1 = "2,3,4";
            var _input2 = "10,3,2";
            var _input3 = "100,2,5";
            var _input4 = "2,3,4";

            //act
            int multi = calc.calculate(_input4, OperationType.Multiply);  // 24 (2*3*4)
            int div = calc.calculate(_input3, OperationType.Divide);    // 10 (100/2/5)
            var suma = calc.calculate(_input1, OperationType.Add);
            int resta = calc.calculate(_input2, OperationType.Subtract); // 5 (10-3-2)


            //assert
            Assert.Equal(9, suma);
            Assert.Equal(5, resta);
            Assert.Equal(24, multi);
            Assert.Equal(10, div);



        }
    }
}
