using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ActManagerTest
    {
        private const string ExpectedActParam = "param", ExpectedActResult = "result";

        [Fact]
        public void ActManager_Provides_AssertManager()
        {
            // Arrange
            bool actExecuted = false;

            // Act
            AssertManager<string> manager =
                new ActManager<string>(ExpectedActParam)
                .Act(param =>
                {
                    actExecuted = param == ExpectedActParam;
                    return ExpectedActResult;
                });

            // Assert
            manager.ShouldNotBeNull();
            manager.ActResult.ShouldBe(ExpectedActResult);
        }

        [Fact]
        public void ActManager_Provides_LigthAssertManager()
        {
            // Arrange
            bool actExecuted = false;

            // Act
            object manager =
                new ActManager<string>(ExpectedActParam)
                .Act(param => { actExecuted = param == ExpectedActParam; });

            // Assert
            actExecuted.ShouldBeTrue();
            manager.ShouldBeOfType<LightAssertManager>();
        }

        [Fact]
        public void ActManager_With_ExpectedValue_Provides_AssertManager()
        {
            // Arrange
            const string ExpectedValue = "value";
            bool actExecuted = false;

            // Act
            AssertManager<string, string> manager =
                new ActManager<string, string>(ExpectedValue, ExpectedActParam)
                .Act(param =>
                {
                    actExecuted = param == ExpectedActParam;
                    return ExpectedActResult;
                });

            // Assert
            actExecuted.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
            manager.ActResult.ShouldBe(ExpectedActResult);
        }
    }
}
