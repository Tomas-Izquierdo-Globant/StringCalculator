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
        public void AddMultipleNumbers_ReturnsSum()
        {
            var calc = new StringCalculator.Core.StringCalculator();
            Assert.Equal(78, calc.add("1,2,3,4,5,6,7,8,9,10,11,12"));

        }
    }
}
