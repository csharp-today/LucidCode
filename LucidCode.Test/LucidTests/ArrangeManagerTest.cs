using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ArrangeManagerTest
    {
        private const string ExpectedValue = "value";

        [Fact]
        public void ArrangeManager_Provides_ActManager()
        {
            // Arrange
            const string ExpectedParameter = "param";
            bool arrangeExecutedFine = false;

            // Act
            ActManager<string, string> manager =
                new ArrangeManager<string>(ExpectedValue)
                .Arrange(expected =>
                {
                    arrangeExecutedFine = expected == ExpectedValue;
                    return ExpectedParameter;
                });

            // Assert
            arrangeExecutedFine.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
            manager.ActParameter.ShouldBe(ExpectedParameter);
        }

        [Fact]
        public void ArrangeManager_Provides_AssertManager()
        {
            // Arrange
            const string ExpectedResult = "result";
            bool actExecutedFine = false;

            // Act
            AssertManager<string, string> manager =
                new ArrangeManager<string>(ExpectedValue)
                .Act(() =>
                {
                    actExecutedFine = true;
                    return ExpectedResult;
                });

            // Assert
            actExecutedFine.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
            manager.ActResult.ShouldBe(ExpectedResult);
        }

        [Fact]
        public void ArrangeManager_Provides_LightActManager()
        {
            // Arrange
            bool expectedValuePresent = false;

            // Act
            LightActManager<string> manager =
                LucidTest.DefineExpected(ExpectedValue)
                .Arrange(expected =>
                {
                    expectedValuePresent = expected == ExpectedValue;
                });

            // Assert
            expectedValuePresent.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
        }
    }
}
