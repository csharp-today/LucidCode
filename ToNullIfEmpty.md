# LucidCode

## **ToNullIfEmpty** extension method

**Description:** Returns null if string is empty string (`""`), otherwise returns the original value.

It allows handling empty strings the same way as null values.

Examples:

```csharp
using Xunit;
using LucidCode;

namespace Examples.Extensions
{
    public class ToNullIfEmpty
    {
        [Fact]
        public void Examples_Of_ToNullIfEmpty()
        {
            string value = "abc";
            value = value.ToNullIfEmpty() ?? "default";
            Assert.Equal("abc", value);

            value = "";
            value = value.ToNullIfEmpty() ?? "default";
            Assert.Equal("default", value);

            value = null;
            value = value.ToNullIfEmpty() ?? "default";
            Assert.Equal("default", value);
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
    public class ToNullIfEmptyTest
    {
        [Fact]
        public void ToNullIfEmpty_Empty() => LucidTest
            .Act(() => "".ToNullIfEmpty())
            .Assert(result => result.ShouldBeNull());

        [Fact]
        public void ToNullIfEmpty_NotEmpty() => LucidTest
            .DefineExpected("abc")
            .Arrange(value => value)
            .Act(value => value.ToNullIfEmpty())
            .Assert((expectedValue, value) => value.ShouldBe(expectedValue));
    }
}

```
