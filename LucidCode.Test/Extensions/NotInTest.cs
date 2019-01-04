using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace LucidCode.Test.Extensions
{
    public class NotInTest
    {
        [Fact]
        public void NotInArray_Negative() => LucidTest
            .Act(() => 5.NotIn(new[] { 5 }))
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void NotInArray_Positive() => LucidTest
            .Act(() => 5.NotIn(new[] { 1, 2, 3 }))
            .Assert(result => result.ShouldBeTrue());

        [Fact]
        public void NotInCollection_Negative() => LucidTest
            .Arrange(() => (IEnumerable<int>)new[] { 5 })
            .Act(collection => 5.NotIn(collection))
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void NotInCollection_Positive() => LucidTest
            .Arrange(() => (IEnumerable<int>)new[] { 1, 2, 3 })
            .Act(collection => 5.NotIn(collection))
            .Assert(result => result.ShouldBeTrue());

        [Fact]
        public void NotIn_Negative() => LucidTest
            .Act(() => 5.NotIn(1, 2, 3, 4, 5))
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void NotIn_Positive() => LucidTest
            .Act(() => 5.NotIn(1, 2, 3, 4))
            .Assert(result => result.ShouldBeTrue());
    }
}
