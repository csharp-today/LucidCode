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
