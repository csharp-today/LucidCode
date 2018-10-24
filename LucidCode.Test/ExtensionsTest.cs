using Shouldly;
using System.Collections.Generic;
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
        public void InArray_Negative()
        {
            // Act
            var result = 5.In(new[] { 1, 2, 3 });

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void InArray_Positive()
        {
            // Act
            var result = 5.In(new[] { 5 });

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void InCollection_Negative()
        {
            // Arrange
            IEnumerable<int> collection = new[] { 1, 2, 3 };

            // Act
            var result = 5.In(collection);

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void InCollection_Positive()
        {
            // Arrange
            IEnumerable<int> collection = new[] { 5 };

            // Act
            var result = 5.In(collection);

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsNotNull_Negative()
        {
            // Act
            object obj = null;
            var result = obj.IsNotNull();

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void IsNotNull_Positive()
        {
            // Act
            var result = new object().IsNotNull();

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void IsNull_Negative()
        {
            // Act
            var result = new object().IsNull();

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void IsNull_Positive()
        {
            // Act
            object obj = null;
            var result = obj.IsNull();

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void NotInArray_Negative()
        {
            // Act
            var result = 5.NotIn(new[] { 5 });

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void NotInArray_Positive()
        {
            // Act
            var result = 5.NotIn(new[] { 1, 2, 3 });

            // Assert
            result.ShouldBeTrue();
        }

        [Fact]
        public void NotInCollection_Negative()
        {
            // Arrange
            IEnumerable<int> collection = new[] { 5 };

            // Act
            var result = 5.NotIn(collection);

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void NotInCollection_Positive()
        {
            // Arrange
            IEnumerable<int> collection = new[] { 1, 2, 3 };

            // Act
            var result = 5.NotIn(collection);

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
