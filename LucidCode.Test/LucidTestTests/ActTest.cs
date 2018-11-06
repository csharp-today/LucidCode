using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTestTests
{
    public class ActTest
    {
        [Fact]
        public void Act_Returns_ActBundle()
        {
            // Arrange
            const string Expected = "expectedValue", Result = "result";

            // Act
            AssertBundle<string, string> assertBndle = LucidTest.DefineExpected(Expected)
                .Arrange(expected => "actParameter")
                .Act(actParameter => Result);

            // Assert
            assertBndle.ShouldNotBeNull();
            assertBndle.ExpectedValue.ShouldBe(Expected);
            assertBndle.ActResult.ShouldBe(Result);
        }

        [Fact]
        public void Act_Returns_ActResult()
        {
            // Act
            ActResultCarrier<string> actResult = LucidTest.Arrange(() => "param")
                .Act(param => param.ToUpper());

            // Assert
            actResult.ShouldNotBeNull();
            actResult.ActResult.ShouldBe("PARAM");
        }

        [Fact]
        public void Act_Without_Arrange_Returns_ActResult()
        {
            // Arrange
            const string ExpectedResult = "result";

            // Act
            ActResultCarrier<string> actResult = LucidTest.Act(() => ExpectedResult);

            // Assert
            actResult.ShouldNotBeNull();
            actResult.ActResult.ShouldBe(ExpectedResult);
        }
    }
}
