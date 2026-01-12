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
        public void Add_MaxTwoNumbers_ThrowsException()
        {
            var calc = new StringCalculator.Core.StringCalculator();
            var ex = Assert.Throws<Exception>(() => calc.add("1,2,3"));
            Assert.Equal("Solo se permiten hasta 2 números",ex.Message);
        }
    }
}
