using Microsoft.AspNetCore.Mvc;
using NumberToWords.Services;

namespace NumberToWords.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NumberToWordsController: ControllerBase
{
    /// <summary>
    /// Converts numerical input into words and passes these words as a string output parameter.
    /// The input must represent a positive decimal number with up to two decimal places (dollars and cents).
    /// For example: "123.45" is valid; "123.456" or "-123.45" or "abc" is invalid.
    /// </summary>
    /// <param name="input">A string representing the numeric amount. Must be a positive decimal number with at most two decimal places.</param>
    /// <returns>
    /// Returns an HTTP 200 OK response with the words;
    /// Returns an HTTP 400 Bad request if the input is invalid;
    /// </returns>
    private readonly INumberToWordsService _numberToWordsService;
    public NumberToWordsController(INumberToWordsService numberToWordsService)
    {
        _numberToWordsService = numberToWordsService;
    }
    
    [HttpPost]
    public IActionResult Convert([FromBody] string input)
    {
        if (!decimal.TryParse(input, out decimal amount))
        {
            return BadRequest("Invalid input.");
        }

        try
        {
            long dollars = (long)Math.Floor(amount);
            int cents = (int)(amount % 1 * 100);
            
            string dollarsToWords = _numberToWordsService.ConvertNumberToWords(dollars);
            string centsToWords = _numberToWordsService.ConvertNumberToWords(cents);

            string dollarWord = dollars == 1 ? "DOLLAR" : "DOLLARS";
            string centWord = cents == 1 ? "CENT" : "CENTS";
            
            return Ok($"{dollarsToWords} {dollarWord} AND {centsToWords} {centWord}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}