# Approach and Alternative Solutions
## 1.Selected Approach
### Overview
This solution implements a C# Web API and HTML webpage that converts numeric input into its words representation, in the required format for financial amounts:
```csharp
Input: "123.45"
Output: "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS"
```

The solution includes:
```csharp
A Web API endpoint (POST /api/NumberToWords) that accepts the string input and returns corresponding words as a string.  
A service class (NumberToWordsService) with two core methods:
    ConvertsDollarsToWords(string dollarsPart)
    ConvertCentsToWords(int centsPart)
```

## 2.Reasons for Chosen Approach
```csharp
Why separate handle dollars and cents?
        
    - The dollars and cents parts follow different formatting conventions.
    - Dollars can go up to TRILLION.
    - Cents are a simple two-digit number.
    - Separation of logic improves reability, testability, and maintainability.
    
Why string for dollars: 
    - It is more future-proof.
    - It is more robust to very large inputs.
    - It avoids overflow risk.
    - It handles large numbers(TRILLION) safely.
    - Grouping dollars into groups of 3 digits (for THOUSAND, MILLION, BILLION, TRILLION) is more straightforward when working with strings.

Why int for cents?
    - The cents part always falls within the range [0, 99], so it is a safe and efficient choice.
    - Conversion of cents does not require handling of large-scale units.
```

## 3. Alternatives Considered and Rejected
```csharp
Using long to handle dollars part with recursion:
    
    - I initially considered parsing dollars as long and performing arithmetic conversion.
    - Reject because:
        1.Overflow risk:
            Handling extremely large values may cause overflow in long.
            string-based processing is more robust for arbitrary-length inputs.
            
        2.Performance concern with recursion:
            Even for small input values, a recursive solution would need to evaluate multiple conditional branches (if (number / 1_000_000_000 > 0) and so on).
            This adds unnecessary overhead for small numbers.
            An iterative, non-recursive approach avoids this overhead and is more efficient for both small and large numbers.
        
        3.Maintainability and extensibility:
            String-based grouping logic is easier to extend if new scale units are required (e.g. QUADRILLION).
            The iterative method aligns well with common number-to-words conversion patterns.
            
        4.Future-proofing:
            Using string avoids coupling the algorithm to a specific numeric type.
            The service can support arbitrary large inputs in the future with minimal changes.

    
Using a combined method for dollars and cents
    
    - A single method for converting both dollars and cents was considered.
    - Rejected because:
        Dollars and cents require different logic and different formatting.
        Keeping them separate results in cleaner, more modular code.
```