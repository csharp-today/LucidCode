# LucidCode

LucidCode is a library dedicated to improving code readability.

Article on my blog: https://csharp.today/LucidCode

[![Build Status](https://dev.azure.com/mariuszbojkowski/Open%20Source%20projects/_apis/build/status/csharp-today.LucidCode?branchName=master)](https://dev.azure.com/mariuszbojkowski/Open%20Source%20projects/_build/latest?definitionId=8&branchName=master) [![NuGet Version](https://img.shields.io/nuget/v/LucidCode)](https://www.nuget.org/packages/LucidCode/) [![NuGet Downloads](https://img.shields.io/nuget/dt/LucidCode)](https://www.nuget.org/packages/LucidCode/)

## Extension methods

* **[In](Docs/Extensions/In.md)** / **[NotIn](Docs/Extensions/NotIn.md)** - Check if object is in collection
* **[IsNull](Docs/Extensions/IsNull.md)** / **[IsNotNull](Docs/Extensions/IsNotNull.md)** - Check if object is null
* **[ToNullIfEmpty](Docs/Extensions/ToNullIfEmpty.md)** - Return null if string is empty string
* **[ToNullIfWhiteSpace](Docs/Extensions/ToNullIfWhiteSpace.md)** - Return null if string is white space

## LucidTest - Support **Arrange Act Assert** pattern

Arrange Act Assert pattern (AAA) is a very powerful pattern for writing tests. The AAA implementation is usually done by adding comments in the test code:

[embed-code]: # (Examples\LucidTests\TestWithoutLucidTest.cs)

Next good pattern is to avoid comments by writing readable and self-explanable code. What if both patterns could be combined? Here is LucidTest example of such approach:

[embed-code]: # (Examples\LucidTests\TestWithLucidTest.cs)

Here are a few examples of more advanced scenarios for LucidTest.

[embed-code]: # (Examples\LucidTests\AdvancedTestsWithLucidTest.cs)
