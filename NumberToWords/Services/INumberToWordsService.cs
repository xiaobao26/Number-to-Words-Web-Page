namespace NumberToWords.Services;

public interface INumberToWordsService
{
    string ConvertsDollarsToWords(string dollarsPart);
    string ConvertCentsToWords(int centsPart);
}