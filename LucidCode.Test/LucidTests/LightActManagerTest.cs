using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class LightActManagerTest
    {
        [Fact]
        public void ActResult_Present_In_AssertManager()
        {
            // Arrange
            const string ExpectedResult = "value";

            // Act
            AssertManager<string> manager =
                LucidTest.Arrange(() => { })
                .Act(() => ExpectedResult);

            // Assert
            manager.ShouldNotBeNull();
            manager.ActResult.ShouldBe(ExpectedResult);
        }

        [Fact]
        public void ExpectedValue_And_ActResult_Present_In_AssertManager()
        {
            // Arrange
            const string ExpectedValue = "value", ExpectedResult = "result";
            bool expectedValuePresentInArrange = false;

            // Act
            AssertManager<string, string> manager =
                LucidTest.DefineExpected(ExpectedValue)
                .Arrange(expected =>
                {
                    expectedValuePresentInArrange = expected == ExpectedValue;
                })
                .Act(() => ExpectedResult);

            // Assert
            expectedValuePresentInArrange.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
            manager.ActResult.ShouldBe(ExpectedResult);
        }
    }
}
