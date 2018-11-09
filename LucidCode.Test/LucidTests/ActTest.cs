using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ActTest
    {
        [Fact]
        public void Result_Present_In_AssertManager()
        {
            // Arrange
            const string ExpectedResult = "result";

            // Act
            AssertManager<string> manager = LucidTest.Act(() => ExpectedResult);

            // Assert
            manager.ShouldNotBeNull();
            manager.ActResult.ShouldBe(ExpectedResult);
        }
    }
}
