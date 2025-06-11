# Number To Words Web Page
This Web API converts numeric input into its equivalent words representation.

## Overview
This project implements a Web API that converts a numeric input into its words representation, formatted for financial amounts (dollars and cents):
```csharp
Input: "123.45"
Output: "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"
```
The solution is implemented in C# (.NET 9), with a simple HTML frontend for interactive testing.

## Features
```csharp
- Converts both dollars and cents parts to words.
- Supports numbers up to **TRILLION**.
- Fully manual number-to-words algorithm.
- Web API interface (POST endpoint).
- Unit tests provided.
- HTML frontend for interactive testing.
```

## Project Structure
```plaintext
NumberToWordsSolution.sln          → Solution file
NumberToWords/                     → Web API project
NumberToWordsTest/                 → Unit test project
Approach.md                        → Design and reasoning document
TestPlan.md                        → Test plan document
README.md                          → This file
wwwroot/index.html                 → HTML frontend page
```

## Build and Run
```csharp
Prerequisites:
    - .NET 9 SDK installed → https://dotnet.microsoft.com/download
    - Any IDE or editor → Visual Studio, Rider, VS Code, etc.

Build the solution:
    dotnet restore
    dotnet build
    
Run the Application:
    dotnet run --project NumberToWords
    
Run tests:
     dotnet test
    
By default, the API will be hosted at:
     http://localhost:5216/index.html
```



