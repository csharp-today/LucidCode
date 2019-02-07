# LucidCode

LucidCode is a library dedicated to improving code readability.

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
