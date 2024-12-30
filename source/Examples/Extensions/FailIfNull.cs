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
