using LucidCode.LucidTestFundations;
using Shouldly;
using System.Threading.Tasks;
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

        [Fact]
        public void Act_Provides_LightAssertManager()
        {
            // Arrange
            bool actExecutedFine = false;

            // Act
            LightAssertManager manager =
                LucidTest.Act(() => { actExecutedFine = true; });

            // Assert
            manager.ShouldNotBeNull();
            actExecutedFine.ShouldBeTrue();
        }

        [Fact]
        public async Task ActAsync_Provides_LightAssertManager()
        {
            // Arrange
            bool actExecutedFine = false;

            // Act
            LightAssertManager manager = await LucidTest.ActAsync(() =>
                {
                    actExecutedFine = true;
                    return Task.CompletedTask;
                });

            // Assert
            manager.ShouldNotBeNull();
            actExecutedFine.ShouldBeTrue();
        }
    }
}
