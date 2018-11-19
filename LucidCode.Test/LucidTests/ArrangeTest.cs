using LucidCode.LucidTestFundations;
using Shouldly;
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
            // Act
            object manager = LucidTest.Arrange(() => { });

            // Assert
            manager.ShouldBeOfType<LightActManager>();
        }
    }
}
