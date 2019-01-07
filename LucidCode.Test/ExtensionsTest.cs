using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace LucidCode.Test
{
    public class ExtensionsTest
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
