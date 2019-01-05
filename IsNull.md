# LucidCode

## **IsNull** extension method

**Description:** Returns true if object is null

Examples:

```csharp
using LucidCode;
using Xunit;

namespace Examples.Extensions
{
    public class IsNull
    {
        [Fact]
        public void Examples_Of_IsNull_Extension()
        {
            object obj = null;
            Assert.True(
                obj.IsNull()
                );

            obj = new object();
            Assert.False(
                obj.IsNull()
                );

            int? integer = null;
            Assert.True(
                integer.IsNull()
                );

            integer = 7;
            Assert.False(
                integer.IsNull()
                );
        }
    }
}

```

Unit tests included in the LucidCode framework for this extension:

```csharp
using Shouldly;
using Xunit;

namespace LucidCode.Test.Extensions
{
    public class IsNullTest
    {
        [Fact]
        public void IsNull_Negative() => LucidTest
            .Act(() => new object().IsNull())
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void IsNull_Positive() => LucidTest
            .Arrange(() => (object)null)
            .Act(obj => obj.IsNull())
            .Assert(result => result.ShouldBeTrue());
    }
}

```
