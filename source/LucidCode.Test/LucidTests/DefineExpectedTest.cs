using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class DefineExpectedTest
    {
        [Fact]
        public void ExpectedValue_From_Function_Present_In_ArrangeManager()
        {
            // Arrange
            const string ExpectedValue = "value";

            // Act
            ArrangeManager<string> manager = LucidTest.DefineExpected(() => ExpectedValue);

            // Assert
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
        }

        [Fact]
        public void ExpectedValue_Present_In_ArrangeManager()
        {
            // Arrange
            const string ExpectedValue = "value";

            // Act
            ArrangeManager<string> manager = LucidTest.DefineExpected(ExpectedValue);

            // Assert
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
        }
    }
}
