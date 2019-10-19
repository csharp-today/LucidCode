using LucidCode.LucidTestFundations;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ActManagerTest
    {
        private const string ExpectedActParam = "param",
            ExpectedActResult = "result",
            ExpectedValue = "value";

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
        public async Task ActManager_Provides_AssertManager_Async()
        {
            // Arrange
            bool actExecuted = false;

            // Act
            AssertManager<string> manager = await
                new ActManager<string>(ExpectedActParam)
                .ActAsync(param =>
                {
                    actExecuted = param == ExpectedActParam;
                    return Task.FromResult(ExpectedActResult);
                });

            // Assert
            manager.ShouldNotBeNull();
            //manager.ActResult.ShouldBe(ExpectedActResult);
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
        public async Task ActManager_Provides_LigthAssertManager_Async()
        {
            // Arrange
            bool actExecuted = false;

            // Act
            object manager = await
                new ActManager<string>(ExpectedActParam)
                .ActAsync(param =>
                {
                    actExecuted = param == ExpectedActParam;
                    return Task.CompletedTask;
                });

            // Assert
            actExecuted.ShouldBeTrue();
            manager.ShouldBeOfType<LightAssertManager>();
        }

        [Fact]
        public void ActManager_With_ExpectedValue_Provides_AssertManager()
        {
            // Arrange
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

        [Fact]
        public void ActManager_With_ExpectedValue_Provides_LightAssertManager()
        {
            // Arrange
            bool actExecutedFine = false;

            // Act
            LightAssertManager<string> manager =
                new ActManager<string, string>(ExpectedValue, ExpectedActParam)
                .Act(param =>
                {
                    actExecutedFine = param == ExpectedActParam;
                });

            // Assert
            actExecutedFine.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
        }
    }
}
