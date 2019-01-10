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

Unit tests included in the LucidCode library for this extension:

```csharp
using Shouldly;
using Xunit;

namespace LucidCode.Test.Extensions
{
    public class IsNullTest
    {
        [Fact]
        public void IsNull_Class_Negative() => LucidTest
            .Act(() => new object().IsNull())
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void IsNull_Class_Positive() => LucidTest
            .Arrange(() => (object)null)
            .Act(obj => obj.IsNull())
            .Assert(result => result.ShouldBeTrue());

        [Fact]
        public void IsNull_Struct_Negative() => LucidTest
            .Act(() => ((int?)123).IsNull())
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void IsNull_Struct_Positive() => LucidTest
            .Arrange(() => (int?)null)
            .Act(value => value.IsNull())
            .Assert(result => result.ShouldBeTrue());
    }
}

```
