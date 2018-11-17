using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ActTest
    {
        [Fact]
        public void Act_Provides_AssertManager()
        {
            // Arrange
            const string ExpectedResult = "result";
            bool actExecuted = false;

            // Act
            AssertManager<string> manager = LucidTest.Act(() =>
            {
                actExecuted = true;
                return ExpectedResult;
            });

            // Assert
            actExecuted.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ActResult.ShouldBe(ExpectedResult);
        }
    }
}
