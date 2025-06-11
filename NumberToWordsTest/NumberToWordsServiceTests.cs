using Xunit;
using NumberToWords.Services;

namespace NumberToWordsTest
{
    public class NumberToWordsServiceTests
    {
        private readonly INumberToWordsService _service;

        public NumberToWordsServiceTests()
        {
            _service = new NumberToWordsService();
        }

        [Theory(DisplayName = "Valid conversion cases")]
        [InlineData("0",  "ZERO DOLLARS AND ZERO CENTS")]
        [InlineData("1",  "ONE DOLLAR AND ZERO CENTS")]
        [InlineData("15.00",  "FIFTEEN DOLLARS AND ZERO CENTS")]
        [InlineData("123.45",  "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS")]
        [InlineData("1001.0",  "ONE THOUSAND ONE DOLLARS AND ZERO CENTS")]
        [InlineData("1000000.01",  "ONE MILLION DOLLARS AND ONE CENT")]
        [InlineData("999999999999999.99", "NINE HUNDRED NINETY-NINE TRILLION NINE HUNDRED NINETY-NINE BILLION NINE HUNDRED NINETY-NINE MILLION NINE HUNDRED NINETY-NINE THOUSAND NINE HUNDRED AND NINETY-NINE DOLLARS AND NINETY-NINE CENTS")]
        public void ConvertAmountToWords_ShouldReturnExpectedWords(string input, string expected)
        {

            decimal amount = decimal.Parse(input);

            var result = _service.ConvertAmountToWords(input, amount);

            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "Should throw ArgumentException when dollars part exceeds 15 digits")]
        [InlineData("1000000000000000.0")] // 16 digits
        [InlineData("12345678901234567.99")] // 17 digits
        public void ConvertAmountToWords_ShouldThrowArgumentException_WhenDollarsTooLarge(string input)
        {
            decimal amount = decimal.Parse(input);
            Assert.Throws<ArgumentException>(() => _service.ConvertAmountToWords(input, amount));
        }

    }
}
