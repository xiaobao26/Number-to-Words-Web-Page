namespace NumberToWords.Services;

public interface INumberToWordsService
{
    string ConvertAmountToWords(string input, decimal amount);
    string ConvertsDollarsToWords(string dollarsPart);
    string ConvertCentsToWords(int centsPart);

}