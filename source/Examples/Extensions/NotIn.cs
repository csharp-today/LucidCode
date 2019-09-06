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
