# Number To Words Web API
> This Web API converts numeric input into its equivalent words representation.
> 
# Swagger
> http://localhost:5216/swagger

# WorkFlow
```csharp
// User Input (only acceptable numerical input)
// Parse Input
//    - unvalid -> throw exception
//    - valid -> parse as decimal
// Split into doller(s) and cent(s)
// Convert each part to words
// String +=
// Output these words as a string
```