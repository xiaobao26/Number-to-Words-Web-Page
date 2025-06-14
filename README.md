# Number To Words Web Page
This Web page converts numeric input into its equivalent words representation.

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
## Limitations
```csharp
- The system supports dollar amounts up to 15 digits in length (TRILLION level).
- Only positive numbers are supported.
- The input must have at most two decimal places.
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
##  Troubleshooting
```csharp
- Issue: After deployment, the app always showed "Your web app is running and waiting for your content."
- Investigation Steps: 
    1. Noticed two '.csproj' files in the solution (backend service + test). Tried publishing only the backend project → issue persisted.
    2. Discovered 'index.HTML' (uppercase) was not being published on Linux (case-sensitive). 
        Renamed to 'index.html' → static page loaded correctly.
        But url is duplicated: 'https://numbertowordswebpage-ebfyhjdag5bsgfcb.scm.australiacentral-01.azurewebsites.net/wwwroot/wwwroot/'
    3. Found middleware order was incorrect: 'UseDefaultFiles()' must be called before 'UseStaticFiles()' 
- Conclusion:
    1. File names are case-sensitive on Linux.  
    2. Always call 'UseDefaultFiles()' before 'UseStaticFiles()'.  
    3. When publishing multi-project solutions, ensure only the main project's output is included.  
```

