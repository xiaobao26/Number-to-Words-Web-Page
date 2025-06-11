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
    
    private static readonly string[] NumberUnits =
    {
        "", "THOUSAND", "MILLION", "BILLION", "TRILLION"
    }; 
    
    /// <summary>
    /// Converts the dollars part (string type) into its words
    /// Support large number like TRILLION
    /// </summary>
    /// <param name="dollarsPart">The string number("123,456,789") to convert.</param>
    /// <returns>A string containing the words representation of the number</returns>
    public string ConvertsDollarsToWords(string dollarsPart)
    {
        // Padding
        int padding = 3 - (dollarsPart.Length % 3);
        if (padding != 3)
            dollarsPart = dollarsPart.PadLeft(dollarsPart.Length + padding, '0');
        
        // Group into 3-digits groups from right to right 
        var groups = new List<string>();
        for (var i = dollarsPart.Length; i > 0; i -= 3)
        {
            groups.Add(dollarsPart.Substring(i-3, 3));
        }
        
        // Converts each group(string number) firstly to int number, then convert to word 
        var words = new List<string>();
        for (var i = groups.Count - 1; i >= 0; i--)
        {
            // "789" -> 789
            int groupValue = int.Parse(groups[i]);
            
            // Ignore empty group
            if (groupValue == 0)
                continue;
            
            // 789 -> SEVEN HUNDRED EIGHTY (AND) NINE
            bool isLastGroup = (i == 0);
            string groupWords = ConvertThreeDigitGroupToWords(groupValue, isLastGroup);
            words.Add(groupWords);
            
            // Add Number units ("THOUSAND", "MILLION", "BILLION", "TRILLION")
            if (!string.IsNullOrEmpty(NumberUnits[i]))
                words.Add(NumberUnits[i]);
        }
        
        return words.Count == 0 ? "ZERO" : string.Join(" ", words);
    }
    
    /// <summary>
    /// Converts an integer number(int type) into its words.
    /// Handle the range from [0, 99]
    /// </summary>
    /// <param name="number">The integer number to convert.</param>
    /// <returns>A string containing the words representation of the number</returns>
    public string ConvertCentsToWords(int cents)
    {
        string res = "";
        
        if (cents < 20)
        {
            res += UnderTwentyWords[cents];
        }
        else
        {
            res += MultiplesOfTen[cents / 10];
            if (cents % 10 > 0)
            {
                res += UnderTwentyWords[cents % 10];
            }
        }

        return res;
    }

    /// <summary>
    /// Converts a number in the range [0, 999] into words.
    /// Handles "AND" keyword only in the last group.
    /// </summary>
    /// <param name="number">[0, 999] Integre</param>
    /// <returns>The number converted to words.</returns>
    private string ConvertThreeDigitGroupToWords(int number, bool isLastGroup)
    {
        var res = new List<string>();
        
        if (number >= 100)
        {
            res.Add(UnderTwentyWords[number / 100]);
            res.Add("HUNDRED");
            
            // No "AND" used in "THOUSAND", "MILLION", "BILLION", "TRILLION"
            if (isLastGroup && number % 100 > 0)
            {
                res.Add("AND");
            }

            number %= 100;
        }

        if (number >= 20)
        {
            res.Add(MultiplesOfTen[number / 10]);
            if (number % 10 > 0)
            {
                res[res.Count - 1] += "-" + UnderTwentyWords[number % 10];
            }
        }
        else if (number > 0)
        {
            res.Add(UnderTwentyWords[number]);
        }

        return string.Join(" ", res);
    }
}