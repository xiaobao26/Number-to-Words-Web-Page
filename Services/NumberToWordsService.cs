namespace NumberToWords.Services;

public class NumberToWordsService: INumberToWordsService
{
    private static readonly string[] UnderTwentyWords = 
    {
        "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE",
        "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
    };
    
    private static readonly string[] MultiplesOfTen =
    {
        "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
    };
    
    /// <summary>
    /// Converts an integer number(long type) into its words
    /// Handles large numbers: billions, millions, thousands, hundreds, tens and units.
    /// </summary>
    /// <param name="number">The integer number to convert. Must be greater or equal than zero</param>
    /// <returns>A string containing the words representation of the number</returns>
    /// <exception cref="ArgumentOutOfRangeException">Throw exception if number is negative</exception>
    public string ConvertNumberToWords(long number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("Native number cannot be support.");
        }
        if (number == 0)
            return "ZERO";

        var res = new List<string>();
        if (number / 1_000_000_000 > 0)
        {
            res.Add($"{ConvertNumberToWords(number / 1_000_000_000)} BILLION");
            number %= 1_000_000_000;
        }
        if (number / 1_000_000 > 0)
        {
            res.Add($"{ConvertNumberToWords(number / 1_000_000)} MILLION");
            number %= 1_000_000;
        }
        if (number / 1000 > 0)
        {
            res.Add($"{ConvertNumberToWords(number / 1000)} THOUSAND");
            number %= 1000;
        }
        if (number / 100 > 0)
        {
            res.Add($"{ConvertNumberToWords(number / 100)} HUNDRED");
            number %= 100;
        }

        if (number > 0)
        {
            if (res.Count > 0)
                res.Add("AND");
            
            if (number < 20)
            {
                res.Add($"{UnderTwentyWords[number]}");
            }
            else
            {
                res.Add($"{MultiplesOfTen[number / 10]}");
                if (number % 10 > 0)
                {
                    // res.Add($"-{UnderTwentyWords[number % 10]}");
                    res[res.Count - 1] += "-" + UnderTwentyWords[number % 10];
                }
            }
        }

        return string.Join(" ", res);
    }
    
    /// <summary>
    /// Converts an integer number(int type) into its words.
    /// Handle the range from [0, 99]
    /// </summary>
    /// <param name="number">The integer number to convert.</param>
    /// <returns>A string containing the words representation of the number</returns>
    public string ConvertNumberToWords(int number)
    {
        string res = "";
        
        if (number < 20)
        {
            res += UnderTwentyWords[number];
        }
        else
        {
            res += MultiplesOfTen[number / 10];
            if (number % 10 > 0)
            {
                res += UnderTwentyWords[number % 10];
            }
        }

        return res;
    }
}