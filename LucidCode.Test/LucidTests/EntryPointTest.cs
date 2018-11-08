using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class EntryPointTest
    {
        [Fact]
        public void DefineExpected_Returns_ArrangeManager()
        {
            // Arrange
            const string ExpectedValue = "test";

            // Act
            ArrangeManager<string> manager = LucidTest.DefineExpected(ExpectedValue);

            // Assert
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
        }
    }
}
