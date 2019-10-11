using LucidCode.LucidTestFundations;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ArrangeTest
    {
        [Fact]
        public void Arrange_Provides_ActManager()
        {
            // Arrange
            const string ExpectedParameter = "param";
            bool arrangeExecutedFine = false;

            // Act
            ActManager<string> manager = LucidTest.Arrange(() =>
            {
                arrangeExecutedFine = true;
                return ExpectedParameter;
            });

            // Assert
            arrangeExecutedFine.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ActParameter.ShouldBe(ExpectedParameter);
        }

        [Fact]
        public void Arrange_Provides_LightActManager()
        {
            // Arrange
            bool executed = false;

            // Act
            object manager = LucidTest.Arrange(() => { executed = true; });

            // Assert
            executed.ShouldBeTrue();
            manager.ShouldBeOfType<LightActManager>();
        }

        [Fact]
        public async Task ArrangeAsync_Provides_LightActManager()
        {
            // Arrange
            bool executed = false;

            // Act
            object manager = await LucidTest.ArrangeAsync(() =>
            {
                executed = true;
                return Task.CompletedTask;
            });

            // Assert
            executed.ShouldBeTrue();
            manager.ShouldBeOfType<LightActManager>();
        }
    }
}
