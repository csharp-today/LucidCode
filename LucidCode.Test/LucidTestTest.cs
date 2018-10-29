using Shouldly;
using Xunit;
using static LucidCode.LucidTest;

namespace LucidCode.Test
{
    public class LucidTestTest
    {
        [Fact]
        public void Arrange_Returns_Act_Parameters()
        {
            // Arrange
            const string ExpectedActParameter = "expected";

            // Act
            var actParameter = DefineExpected("someValue")
                .Arrange(expected => ExpectedActParameter);

            // Assert
            actParameter.ShouldBe(ExpectedActParameter);
        }

        [Fact]
        public void DefineExpected_Returns_Value()
        {
            // Arrange
            var expectedDefinition = new { Value1 = "test", Value2 = "other" };

            // Act
            var definition = DefineExpected(expectedDefinition);

            // Assert
            definition.ShouldBe(expectedDefinition);
        }
    }
}
