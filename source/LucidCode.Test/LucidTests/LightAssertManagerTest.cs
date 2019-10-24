using LucidCode.LucidTestFundations;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class LightAssertManagerTest
    {
        [Fact]
        public void Execute_Assert_Step()
        {
            // Arrange
            bool executed = false;

            // Act
            new LightAssertManager().Assert(() => executed = true);

            // Assert
            executed.ShouldBeTrue();
        }

        [Fact]
        public async Task Execute_Assert_Step_Async()
        {
            // Arrange
            bool executed = false;

            // Act
            await new LightAssertManager().AssertAsync(() =>
            {
                executed = true;
                return Task.CompletedTask;
            });

            // Assert
            executed.ShouldBeTrue();
        }

        [Fact]
        public void Execute_Assert_Step_With_ExpectedValue()
        {
            // Arrange
            const string ExpectedValue = "value";
            bool executedFine = false;

            // Act
            new LightAssertManager<string>(ExpectedValue)
                .Assert(expected =>
                {
                    executedFine = expected == ExpectedValue;
                });

            // Assert
            executedFine.ShouldBeTrue();
        }
    }
}
