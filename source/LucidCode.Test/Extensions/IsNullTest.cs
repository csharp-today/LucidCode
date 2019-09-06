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
