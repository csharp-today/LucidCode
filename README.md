# LucidCode

LucidCode is a library dedicated to improving code readability.

## Extension methods

* **[In](Docs/Extensions/In.md)** / **[NotIn](Docs/Extensions/NotIn.md)** - Check if object is in collection
* **[IsNull](Docs/Extensions/IsNull.md)** / **[IsNotNull](Docs/Extensions/IsNotNull.md)** - Check if object is null
* **[ToNullIfEmpty](Docs/Extensions/ToNullIfEmpty.md)** - Return null if string is empty string
* **[ToNullIfWhiteSpace](Docs/Extensions/ToNullIfWhiteSpace.md)** - Return null if string is white space

## LucidTest - Support **Arrange Act Assert** pattern

Arrange Act Assert pattern (AAA) is a very powerful pattern for writing tests. The AAA implementation is usually done by adding comments in the test code:

```csharp
using Shouldly;
using Xunit;

namespace Examples.LucidTests
{
    public class TestWithoutLucidTest
    {
        [Fact]
        public void Test_NameProvider()
        {
            // Arrange
            var nameProvider = new NameProvider();

            // Act
            var userName = nameProvider.GetUserName(0);

            // Assert
            userName.ShouldBe("Admin");
        }
    }
}
```

Next good pattern is to avoid comments by writing readable and self-explanable code. What if both patterns could be combined? Here is LucidTest example of such approach:

```csharp
using LucidCode;
using Shouldly;
using Xunit;

namespace Examples.LucidTests
{
    public class TestWithLucidTest
    {
        [Fact]
        public void Test_NameProvider() => LucidTest
            .Arrange(() => new NameProvider())
            .Act(provider => provider.GetUserName(0))
            .Assert(result => result.ShouldBe("Admin"));
    }
}
```

Here are a few examples of more advanced scenarios for LucidTest.

```csharp
using LucidCode;
using Shouldly;
using Xunit;

namespace Examples.LucidTests
{
    public class AdvancedTestsWithLucidTest
    {
        [Fact]
        public void Test_Admin_User() => LucidTest
            .Arrange(CreateNameProvider)
            .Act(provider => provider.GetUserName(0))
            .Assert(result => result.ShouldBe("Admin"));

        [Fact]
        public void Test_Boss_User() => LucidTest
            .Arrange(CreateNameProvider)
            .Act(provider => provider.GetUserName(1))
            .Assert(result => result.ShouldBe("Boss"));

        [Fact]
        public void Test_Complex_Case() => LucidTest
            .DefineExpected(new
            {
                UserName = "PowerUser",
                UserId = 123,
                SomeOtherNeededValue = "I love tests!"
            })
            .Arrange(expected =>
            {
                var provider = CreateNameProvider();

                /* More provider setup logic here
                 * Can use any value defined in 'DefineExpected'
                 */

                return new
                {
                    Provider = provider,
                    expected.UserId
                };
            })
            .Act(param =>
            {
                var result = param.Provider.GetUserName(param.UserId);
                
                /*
                 * Here put more Act things
                 */

                return result;
            })
            .Assert((expected, result) =>
            {
                /* Do advanced asserts using defined
                 * expected values and result
                 */
            });

        private INameProvider CreateNameProvider() => new NameProvider();
    }
}
```
