# LucidCode

## **FailIfNull** extension method

**Description:** Fail if object is null

Examples:

```csharp
using LucidCode;
using System;
using Xunit;

namespace Examples.Extensions;

public class FailIfNull
{
    [Fact]
    public void Examples_Of_FailIfNull_Extension()
    {
        string value = "SomeValue";
        Assert.Equal(
            "SomeValue",
            value.FailIfNull()
            );

        string nullValue = null;
        ArgumentNullException argumentNullException = null;
        try
        {
            nullValue.FailIfNull();
        }
        catch (ArgumentNullException ex)
        {
            argumentNullException = ex;
        }
        Assert.NotNull(argumentNullException);
        Assert.Equal(
            nameof(nullValue),
            argumentNullException.ParamName
            );
    }
}

```

Unit tests included in the LucidCode library for this extension:

```csharp
using Shouldly;
using System;
using Xunit;

namespace LucidCode.Test.Extensions;

public class FailIfNullTest
{
    [Fact]
    public void ShouldReturnValue_WhenInputIsNotNull() => LucidTest
        .DefineExpected("expectedValue")
        .Arrange(x => x)
        .Act(value => value.FailIfNull())
        .Assert((expected, value) => value.ShouldBe(expected));

    [Fact]
    public void ShouldThrowException_WhenInputIsNull() => LucidTest
        .Arrange(() => (string)null)
        .Act(valueVariableName =>
        {
            try
            {
                valueVariableName.FailIfNull();
                return (Exception: null, VariableName: nameof(valueVariableName));
            }
            catch (Exception excaption)
            {
                return (Exception: excaption, VariableName: nameof(valueVariableName));
            }
        })
        .Assert(output =>
        {
            output.Exception.ShouldNotBeNull();
            var argumentException = output.Exception.ShouldBeOfType<ArgumentNullException>();
            argumentException.ParamName.ShouldBe(output.VariableName);
        });
}

```
