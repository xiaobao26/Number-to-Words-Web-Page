namespace NumberToWords.Services;

public interface INumberToWordsService
{
    string ConvertNumberToWords(long number);
    string ConvertNumberToWords(int number);
}