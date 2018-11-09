using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class AssertManagerTest
    {
        [Fact]
        public void Has_Act_Result()
        {
            // Arrange
            const string ExpectedResult = "result";
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
            const string ExpectedValue = "value", ExpectedResult = "result";
            string expectedValue = null, actResult = null;

            // Act
            LucidTest.DefineExpected(ExpectedValue)
                .Arrange(_ => "param")
                .Act(_ => ExpectedResult)
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
