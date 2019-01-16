# LucidCode

## **ToNullIfWhiteSpace** extension method

**Description:** Returns null if string is white space string (e.g. `"   "`), otherwise returns the original value.

It allows handling white space strings the same way as null values.

Examples:

```csharp
using Xunit;
using LucidCode;

namespace Examples.Extensions
{
    public class ToNullIfWhiteSpace
    {
        [Fact]
        public void Examples_Of_ToNullIfWhiteSpace()
        {
            string value = "abc";
            value = value.ToNullIfWhiteSpace() ?? "default";
            Assert.Equal("abc", value);

            value = "   ";
            value = value.ToNullIfWhiteSpace() ?? "default";
            Assert.Equal("default", value);

            value = "";
            value = value.ToNullIfWhiteSpace() ?? "default";
            Assert.Equal("default", value);

            value = null;
            value = value.ToNullIfWhiteSpace() ?? "default";
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
    public class ToNullIfWhiteSpaceTest
    {
        [Fact]
        public void ToNullIfWhiteSpace_NotWhiteSpace() => LucidTest
            .DefineExpected("abc")
            .Arrange(value => value)
            .Act(value => value.ToNullIfWhiteSpace())
            .Assert((expectedValue, value) => value.ShouldBe(expectedValue));

        [Fact]
        public void ToNullIfWhiteSpace_WhiteSpace() => LucidTest
            .Act(() => "   ".ToNullIfWhiteSpace())
            .Assert(result => result.ShouldBeNull());
    }
}

```
