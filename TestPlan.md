# Test Plan for Number to Words Web Page
> Verify that HTML and API NumberToWords convert numerical input into words and pass these words as a string output parameter.

## Test Scope
> API endpoint: POST /api/NumberToWords
> HTML frontend: index.html page

## Integrate Test Cases
| Test Case ID | Input                   | Expected Output                                              |
|--------------|-------------------------|--------------------------------------------------------------|
| Id01         | "0"                     | "ZERO DOLLARS AND ZERO CENTS"                                |
| Id02         | "123.45"                | “ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS”  |
| Id03         | "-123.45"               | "Negative input cannot be support.                           |
| Id04         | "1"                     | "ONE DOLLAR AND ZERO CENTS"                                  |
| Id05         | "abc"                   | "Invalid input."                                             |
| Id06         | "1.01"                  | "ONE DOLLAR AND ONE CENT"                                    |
| Id07         | "999999999999999.99"    | "NINE HUNDRED NINETY-NINE TRILLION NINE HUNDRED NINETY-NINE BILLION NINE HUNDRED NINETY-NINE MILLION NINE HUNDRED NINETY-NINE THOUSAND NINE HUNDRED AND NINETY-NINE DOLLARS AND NINETYNINE CENTS"                                                        |
| Id08         | "123456789999999999.99" | "Large number out of range."                                 |

## Test Methodology
> Manual testing via HTML frontend (http://localhost:5216/index.html)
> Direct API testing via Swagger (http://localhost:5216/swagger)
> dotnet test

## Limitations
> The system supports dollar amounts up to 15 digits in length (TRILLION scale).
> Only positive numbers are supported.
> The input must have at most two decimal places.

## Result
> All tested cases passed as expected.