using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ArrangeTest
    {
        [Fact]
        public void Act_Parameter_Present_In_ActManager()
        {
            // Arrange
            const string ExpectedParameter = "param";

            // Act
            ActManager<string> manager = LucidTest.Arrange(() => ExpectedParameter);

            // Assert
            manager.ShouldNotBeNull();
            manager.ActParameter.ShouldBe(ExpectedParameter);
        }

        [Fact]
        public void Arrange_Returns_LightActManager()
        {
            // Act
            var manager = LucidTest.Arrange(() => { });

            // Assert
            manager.ShouldBeOfType<LightActManager>();
        }
    }
}
