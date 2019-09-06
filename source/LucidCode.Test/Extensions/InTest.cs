using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace LucidCode.Test.Extensions
{
    public class InTest
    {
        [Fact]
        public void In_Negative() => LucidTest
            .Act(() => 5.In(1, 2, 3, 4, 6, 7, 8, 9))
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void In_Positive() => LucidTest
            .Act(() => 5.In(1, 2, 3, 5, 7, 9))
            .Assert(result => result.ShouldBeTrue());

        [Fact]
        public void InArray_Negative() => LucidTest
            .Act(() => 5.In(new[] { 1, 2, 3 }))
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void InArray_Positive() => LucidTest
            .Act(() => 5.In(new[] { 5 }))
            .Assert(result => result.ShouldBeTrue());

        [Fact]
        public void InCollection_Negative() => LucidTest
            .Arrange(() => (IEnumerable<int>)new[] { 1, 2, 3 })
            .Act(collection => 5.In(collection))
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void InCollection_Positive() => LucidTest
            .Arrange(() => (IEnumerable<int>)new[] { 5 })
            .Act(collection => 5.In(collection))
            .Assert(result => result.ShouldBeTrue());
    }
}
