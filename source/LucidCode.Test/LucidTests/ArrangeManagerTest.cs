using LucidCode.LucidTestFundations;
using Shouldly;
using System.Threading.Tasks;
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
        public async Task ArrangeManager_Provides_ActManager_Async()
        {
            // Arrange
            const string ExpectedParameter = "param";
            bool arrangeExecutedFine = false;

            // Act
            ActManager<string, string> manager = await new ArrangeManager<string>(ExpectedValue)
                .ArrangeAsync(expected =>
                {
                    arrangeExecutedFine = expected == ExpectedValue;
                    return Task.FromResult(ExpectedParameter);
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
        public async Task ArrangeManager_Provides_AssertManager_Async()
        {
            // Arrange
            const string ExpectedResult = "result";
            bool actExecutedFine = false;

            // Act
            AssertManager<string, string> manager = await new ArrangeManager<string>(ExpectedValue)
                .ActAsync(() =>
                {
                    actExecutedFine = true;
                    return Task.FromResult(ExpectedResult);
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

        [Fact]
        public async Task ArrangeManager_Provides_LightActManager_Async()
        {
            // Arrange
            bool expectedValuePresent = false;

            // Act
            LightActManager<string> manager = await LucidTest
                .DefineExpected(ExpectedValue)
                .ArrangeAsync(expected =>
                {
                    expectedValuePresent = expected == ExpectedValue;
                    return Task.CompletedTask;
                });

            // Assert
            expectedValuePresent.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
        }

        [Fact]
        public void ArrangeManager_Provides_LightAssertManager()
        {
            // Arrange
            bool actExecutedFine = false;

            // Act
            LightAssertManager<string> manager =
                new ArrangeManager<string>(ExpectedValue)
                .Act(() => { actExecutedFine = true; });

            // Assert
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
            actExecutedFine.ShouldBeTrue();
        }

        [Fact]
        public async Task ArrangeManager_Provides_LightAssertManager_Async()
        {
            // Arrange
            bool actExecutedFine = false;

            // Act
            LightAssertManager<string> manager = await new ArrangeManager<string>(ExpectedValue)
                .ActAsync(() =>
                {
                    actExecutedFine = true;
                    return Task.CompletedTask;
                });

            // Assert
            actExecutedFine.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
        }
    }
}
