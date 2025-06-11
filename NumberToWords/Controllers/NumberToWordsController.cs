using Microsoft.AspNetCore.Mvc;
using NumberToWords.Services;

namespace NumberToWords.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NumberToWordsController: ControllerBase
{
    /// <summary>
    /// Converts numerical input into words and output these words as a string.
    /// The input must represent a positive decimal number with up to two decimal places (dollars and cents).
    /// For example: "123.45" is valid; "123.456" or "-123.45" or "abc" is invalid.
    /// </summary>
    /// <param name="input">A string representing the numeric amount. Must be a positive decimal number with at most two decimal places.</param>
    /// <returns>
    /// Returns an HTTP 200 OK response with the words;
    /// Returns an HTTP 400 Bad request if the input is invalid;
    /// Returns an HTTP 500 
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

        if (amount < 0)
        {
            return BadRequest("Negative input cannot be support.");
        }

        try
        {
            var result = _numberToWordsService.ConvertAmountToWords(input, amount);
            return Ok(result);
        }
        // The system supports dollar amounts up to 15 digits in length (TRILLION scale).
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}