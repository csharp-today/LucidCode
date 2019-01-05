# LucidCode

LucidCode is a library dedicated to improving code readability.

## Extension methods

* **[In](In.md)** / **[NotIn](NotIn.md)** - Check if object is in collection
* **[IsNull](IsNull.md)** / **IsNotNull** - Check if object is null

## LucidTest - Arrange Act Assert pattern

Arrange Act Assert pattern (AAA) is a very powerful pattern for writing tests. The AAA implementation is usually done by adding comments in the test code:

```csharp
        private readonly INameProvider _nameProvider = Substitute.For<INameProvider>();

        [Fact]
        public void Test_NameProvider()
        {
            // Arrange
            const string ExpectedName = "FakeName";
            const int UserId = 10;
            _nameProvider.GetUserName(UserId).Returns(ExpectedName);

            // Act
            var userName = _nameProvider.GetUserName(UserId);

            // Assert
            userName.ShouldBe(ExpectedName);
        }
```

Next good pattern is to avoid comments by writing readable and self-explanable code. What if both patterns could be combined? Here is LucidTest example of such approach:

```csharp
        private readonly INameProvider _nameProvider = Substitute.For<INameProvider>();

        [Fact]
        public void Test_NameProvider() =>
            LucidTest.DefineExpected("FakeName")
            .Arrange(name =>
            {
                const int UserId = 10;
                _nameProvider.GetUserName(UserId).Returns(name);
                return UserId;
            })
            .Act(userId => _nameProvider.GetUserName(userId))
            .Assert((expected, result) => result.ShouldBe(expected));
```
