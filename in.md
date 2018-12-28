# LucidCode

## **In** extension

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
