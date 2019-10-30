using LucidCode.LucidTestFundations;
using Shouldly;
using System.Threading.Tasks;
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
        public async Task Has_Act_Result_Async()
        {
            // Arrange
            string actResult = null;

            // Act
            await LucidTest.Act(() => ExpectedResult)
                .AssertAsync(result =>
                {
                    actResult = result;
                    return Task.CompletedTask;
                });

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
                .Assert((expected, result) =>
                {
                    expectedValue = expected;
                    actResult = result;
                });

            // Assert
            expectedValue.ShouldBe(ExpectedValue);
            actResult.ShouldBe(ExpectedResult);
        }

        [Fact]
        public async Task Has_Expected_Value_And_Act_Result_Async()
        {
            // Arrange
            const string ExpectedValue = "value";
            string expectedValue = null, actResult = null;

            // Act
            await new AssertManager<string, string>(ExpectedValue, ExpectedResult)
                .AssertAsync((expected, result) =>
                {
                    expectedValue = expected;
                    actResult = result;
                    return Task.CompletedTask;
                });

            // Assert
            expectedValue.ShouldBe(ExpectedValue);
            actResult.ShouldBe(ExpectedResult);
        }
    }
}
