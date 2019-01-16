# LucidCode

## **In** extension method

**Description:** Returns true if object is in collection

Examples:

```csharp
using LucidCode;
using System.Collections.Generic;
using Xunit;

namespace Examples.Extensions
{
    public class In
    {
        [Fact]
        public void Examples_Of_In_Extension()
        {
            Assert.True(
                5.In(4, 5, 6)
                );

            Assert.False(
                5.In(1, 2, 3)
                );

            IEnumerable<int> collection1 = new[] { 4, 5, 6 };
            Assert.True(
                5.In(collection1)
                );

            IEnumerable<int> collection2 = new[] { 1, 2, 3 };
            Assert.False(
                5.In(collection2)
                );
        }
    }
}

```

Unit tests included in the LucidCode library for this extension:

```csharp
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

```
