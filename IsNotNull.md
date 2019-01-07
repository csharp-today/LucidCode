# LucidCode

## **IsNotNull** extension method

**Description:** Returns true if object is NOT null

Examples:

```csharp
using LucidCode;
using Xunit;

namespace Examples.Extensions
{
    public class IsNotNull
    {
        [Fact]
        public void Examples_Of_IsNotNull_Extension()
        {
            object obj = new object();
            Assert.True(
                obj.IsNotNull()
                );

            obj = null;
            Assert.False(
                obj.IsNotNull()
                );

            int? integer = 7;
            Assert.True(
                integer.IsNotNull()
                );

            integer = null;
            Assert.False(
                integer.IsNotNull()
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
    public class IsNotNullTest
    {
        [Fact]
        public void IsNotNull_Class_Negative() => LucidTest
            .Arrange(() => (object)null)
            .Act(obj => obj.IsNotNull())
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void IsNotNull_Class_Positive() => LucidTest
            .Act(() => new object().IsNotNull())
            .Assert(result => result.ShouldBeTrue());

        [Fact]
        public void IsNotNull_Struct_Negative() => LucidTest
            .Arrange(() => (int?)null)
            .Act(obj => obj.IsNotNull())
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void IsNotNull_Struct_Positive() => LucidTest
            .Act(() => ((int?)12345).IsNotNull())
            .Assert(result => result.ShouldBeTrue());
    }
}

```
