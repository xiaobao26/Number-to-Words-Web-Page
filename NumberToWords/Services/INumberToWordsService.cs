namespace NumberToWords.Services;

public interface INumberToWordsService
{
    string ConvertAmountToWords(string input, decimal amount);
}