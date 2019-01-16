# LucidCode

## **NotIn** extension method

**Description:** Returns true if object is NOT in collection

Examples:

```csharp
using LucidCode;
using System.Collections.Generic;
using Xunit;

namespace Examples.Extensions
{
    public class NotIn
    {
        [Fact]
        public void Examples_Of_NotIn_Extension()
        {
            Assert.True(
                5.NotIn(1, 2, 3)
                );

            Assert.False(
                5.NotIn(5, 6, 7)
                );

            IEnumerable<int> collection1 = new[] { 1, 2, 3 };
            Assert.True(
                5.NotIn(collection1)
                );

            IEnumerable<int> collection2 = new[] { 5, 6, 7 };
            Assert.False(
                5.NotIn(collection2)
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

```
