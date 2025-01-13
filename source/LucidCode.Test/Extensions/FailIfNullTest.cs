using Shouldly;
using System;
using Xunit;

namespace LucidCode.Test.Extensions;

public class FailIfNullTest
{
    [Fact]
    public void ShouldReturnIntValue_WhenInputIsNotNull() => LucidTest
        .DefineExpected(1234)
        .Arrange(x => (int?)x)
        .Act(value => value.FailIfNull())
        .Assert((expected, value) => value.ShouldBe(expected));

    [Fact]
    public void ShouldReturnValue_WhenInputIsNotNull() => LucidTest
        .DefineExpected("expectedValue")
        .Arrange(x => x)
        .Act(value => value.FailIfNull())
        .Assert((expected, value) => value.ShouldBe(expected));

    [Fact]
    public void ShouldThrowException_WhenInputIntIsNull() => LucidTest
        .Arrange(() => (int?)null)
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
