using Shouldly;
using Xunit;

namespace LucidCode.Test.Extensions
{
    public class IsNullTest
    {
        [Fact]
        public void IsNull_Negative() => LucidTest
            .Act(() => new object().IsNull())
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void IsNull_Positive() => LucidTest
            .Arrange(() => (object)null)
            .Act(obj => obj.IsNull())
            .Assert(result => result.ShouldBeTrue());
    }
}
