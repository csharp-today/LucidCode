using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTestTests
{
    public class DefineExpectedTest
    {
        [Fact]
        public void DefineExpected_Returns_Value()
        {
            // Arrange
            var expectedDefinition = "test";

            // Act
            BaseExpectedValue<string> definition = LucidTest.DefineExpected(expectedDefinition);

            // Assert
            definition.ShouldNotBeNull();
            definition.ExpectedValue.ShouldBe(expectedDefinition);
        }
    }
}
