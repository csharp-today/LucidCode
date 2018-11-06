using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTestTests
{
    public class AssertTest
    {
        [Fact]
        public void Assert_With_ActResult()
        {
            // Arrange
            const string ExpectedResult = "result";
            string result = null;

            // Act
            LucidTest.Act(() => ExpectedResult)
                .Assert(r => result = r);

            // Assert
            result.ShouldBe(ExpectedResult);
        }

        [Fact]
        public void Assert_With_AssertBundle()
        {
            // Arrange
            const string Expected = "expectedValue", Result = "result";
            string expectedValue = null, resultValue = null;

            // Act
            LucidTest.DefineExpected(Expected)
                .Arrange(expected => "actParameter")
                .Act(actParameter => Result)
                .Assert((result, expected) =>
                {
                    resultValue = result;
                    expectedValue = expected;
                });

            // Assert
            expectedValue.ShouldBe(Expected);
            resultValue.ShouldBe(Result);
        }
    }
}
