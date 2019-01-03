using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace LucidCode.Test
{
    public class ExtensionsTest
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

        [Fact]
        public void IsNull_Negative() => LucidTest
            .Act(() => new object().IsNull())
            .Assert(result => result.ShouldBeFalse());

        [Fact]
        public void IsNull_Positive() => LucidTest
            .Arrange(() => (object)null)
            .Act(obj => obj.IsNull())
            .Assert(result => result.ShouldBeTrue());

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
