using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ArrangeManagerTest
    {
        [Fact]
        public void ExpectedValue_And_ActParameter_Present_In_ActManager()
        {
            // Arrange
            const string ExpectedValue = "value", ExpectedParameter = "param";

            // Act
            ActManager<string, string> manager =
                LucidTest.DefineExpected(ExpectedValue)
                .Arrange(_ => ExpectedParameter);

            // Assert
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
            manager.ActParameter.ShouldBe(ExpectedParameter);
        }
    }
}
