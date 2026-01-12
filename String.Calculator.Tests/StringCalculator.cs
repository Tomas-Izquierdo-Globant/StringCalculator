namespace String.Calculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            var calc = new StringCalculator.Core.StringCalculator();
            Assert.Equal(0, calc.add(""));

        }

        [Fact]
        public void Add_SingleNumber_ReturnsSameNumber()
        {
            var calc = new StringCalculator.Core.StringCalculator();
            Assert.Equal(20, calc.add("20"));

        }

        [Fact]
        public void Add_SingleNumber_ReturnsSum()
        {
            var calc = new StringCalculator.Core.StringCalculator();
            Assert.Equal(5001, calc.add("5000,1"));

        }
        [Fact]
        public void Add_SingleNumber_TreatedAsZero()
        {
            var calc = new StringCalculator.Core.StringCalculator();
            Assert.Equal(5, calc.add("5,qwerty"));
        }
        [Fact]
        public void Add_MultipleNumbers_ReturnsSum()
        {
            var calc = new StringCalculator.Core.StringCalculator();
            Assert.Equal(78, calc.add("1,2,3,4,5,6,7,8,9,10,11,12"));

        }
        [Fact]
        public void AddNewLineDelimeter_ReturnsSum()
        {
            var calc = new StringCalculator.Core.StringCalculator();
            Assert.Equal(6, calc.add("1\n2,3"));

        }
        [Fact]
        public void AddNegativeNumbers_ThrowsException()
        {
            var calc = new StringCalculator.Core.StringCalculator();
            var ex = Assert.Throws<ArgumentException>(() => calc.add("2,-4,3,-5"));

            Assert.Contains("-4", ex.Message);
            Assert.Contains("-5", ex.Message);

        }
    }
}
