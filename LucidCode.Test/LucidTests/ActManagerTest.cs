using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ActManagerTest
    {
        [Fact]
        public void ExpectedValue_And_Result_Present_In_AssertManager()
        {
            // Arrange
            const string ExpectedValue = "value", ExpectedResult = "result";

            // Act
            AssertManager<string, string> manager =
                LucidTest.DefineExpected(ExpectedValue)
                .Arrange(_ => "param")
                .Act(_ => ExpectedResult);

            // Assert
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
            manager.ActResult.ShouldBe(ExpectedResult);
        }

        [Fact]
        public void LightAssertManager()
        {
            // Arrange
            const string ExpectedParam = "param";
            bool actExecuted = false;

            // Act
            object manager =
                LucidTest.Arrange(() => ExpectedParam)
                .Act(p => { actExecuted = p == ExpectedParam; });

            // Assert
            actExecuted.ShouldBeTrue();
            manager.ShouldBeOfType<LightAssertManager>();
        }

        [Fact]
        public void Result_Present_In_AssertManager()
        {
            // Arrange
            const string ExpectedResult = "result";

            // Act
            AssertManager<string> manager =
                LucidTest.Arrange(() => "param")
                .Act(_ => ExpectedResult);

            // Assert
            manager.ShouldNotBeNull();
            manager.ActResult.ShouldBe(ExpectedResult);
        }
    }
}
