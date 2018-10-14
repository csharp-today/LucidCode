using Shouldly;
using Xunit;

namespace LucidCode.Test
{
    public class ExtensionsTest
    {
        [Fact]
        public void In_Negative()
        {
            // Act
            var result = 5.In(1, 2, 3, 4, 6, 7, 8, 9);

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void In_Positive()
        {
            // Act
            var result = 5.In(1, 2, 3, 5, 7, 9);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void NotIn_Negative()
        {
            // Act
            var result = 5.NotIn(1, 2, 3, 4, 5);

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void NotIn_Positive()
        {
            // Act
            var result = 5.NotIn(1, 2, 3, 4);

            // Assert
            result.ShouldBeTrue();
        }
    }
}
