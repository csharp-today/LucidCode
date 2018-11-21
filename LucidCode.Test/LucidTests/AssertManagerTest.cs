using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class AssertManagerTest
    {
        private const string ExpectedResult = "result";

        [Fact]
        public void Has_Act_Result()
        {
            // Arrange
            string actResult = null;

            // Act
            LucidTest.Act(() => ExpectedResult)
                .Assert(result => actResult = result);

            // Assert
            actResult.ShouldBe(ExpectedResult);
        }

        [Fact]
        public void Has_Expected_Value_And_Act_Result()
        {
            // Arrange
            const string ExpectedValue = "value";
            string expectedValue = null, actResult = null;

            // Act
            new AssertManager<string, string>(ExpectedValue, ExpectedResult)
                .Assert((result, expected) =>
                {
                    expectedValue = expected;
                    actResult = result;
                });

            // Assert
            expectedValue.ShouldBe(ExpectedValue);
            actResult.ShouldBe(ExpectedResult);
        }
    }
}
