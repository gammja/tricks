using Xunit;

namespace tricks.Tests
{
    public class ParseHelperTests
    {
        [Theory]
        [InlineData("123", 123)]
        [InlineData("AAA", null)]
        [InlineData("", null)]
        [InlineData("   ", null)]
        [InlineData(null, null)]
        public void TryParse_Test(string input, int? expected)
        {
            var result = ParseHelper.TryParse(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TryParse_Pipe()
        {
            string number1 = null;
            string number2 = "111";
            string number3 = "AAA";

            // old style
            int ret = -1;
            var t = int.TryParse(number1, out ret) || 
                    int.TryParse(number2, out ret) ||
                    int.TryParse(number3, out ret);


            // new style
            var result = ParseHelper.TryParse(number1) ??
                         ParseHelper.TryParse(number2) ??
                         ParseHelper.TryParse(number3) ??
                         -1;

            Assert.Equal(111, result);
        }
    }
}