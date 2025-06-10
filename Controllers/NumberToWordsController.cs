using Microsoft.AspNetCore.Mvc;

namespace NumberToWords.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NumberToWordsController: ControllerBase
{
    /// <summary>
    /// Convert numerical input into words and passes these words as a string output parameter.
    /// The input must represent a positive decimal number with up to two decimal places (dollars and cents).
    /// For example: "123.45" is valid; "123.456" or "-123.45" or "abc" is invalid.
    /// </summary>
    /// <param name="input">A string representing the numeric amount. Must be a positive decimal number with at most two decimal places.</param>
    /// <returns>
    /// Returns an HTTP 200 OK response with the words;
    /// Returns an HTTP 400 Bad request if the input is invalid;
    /// </returns>
    [HttpPost]
    public IActionResult Convert([FromBody] string input)
    {
        if (!decimal.TryParse(input, out decimal amount))
        {
            return BadRequest("Invalid input.");
        }

        try
        {
            long dollors = (long)Math.Floor(amount);
            int cents = (int)(amount % 1 * 100);
            
            //TODO
            return Ok($"Success: {dollors} AND {cents}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}