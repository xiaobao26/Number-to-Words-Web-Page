using Xunit;
using NumberToWords.Services;

namespace NumberToWordsTest;

public class NumberToWordsServiceTests
{
    private readonly NumberToWordsService _service;

    public NumberToWordsServiceTests()
    {
        _service = new NumberToWordsService();
    }

    [Theory]
    [InlineData("0", "ZERO")]
    [InlineData("1", "ONE")]
    [InlineData("15", "FIFTEEN")]
    [InlineData("123", "ONE HUNDRED AND TWENTY-THREE")]
    public void ConvertsDollarsToWords_ShouldReturnExpectedWords(string input, string expected)
    {
        var result = _service.ConvertsDollarsToWords(input);

        Assert.StartsWith(expected, result);
    }

    [Theory]
    [InlineData(0, "ZERO")]
    [InlineData(1, "ONE")]
    [InlineData(45, "FORTY-FIVE")]
    [InlineData(99, "NINETY-NINE")]
    public void ConvertCentsToWords_ShouldReturnExpectedWords(int input, string expected)
    {
        var result = _service.ConvertCentsToWords(input);

        Assert.Equal(expected, result);
    }
}