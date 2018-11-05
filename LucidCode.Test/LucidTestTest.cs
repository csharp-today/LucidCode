using Shouldly;
using Xunit;
using static LucidCode.LucidTest;

namespace LucidCode.Test
{
    public class LucidTestTest
    {
        [Fact]
        public void Act_Returns_Result()
        {
            // Arrange
            const string Expected = "expectedValue", Result = "result";

            // Act
            var assertBndle = DefineExpected(Expected)
                .Arrange(expected => "actParameter")
                .Act(actParameter => Result);

            // Assert
            assertBndle.ShouldNotBeNull();
            assertBndle.ExpectedValue.ShouldBe(Expected);
            assertBndle.ActResult.ShouldBe(Result);
        }

        [Fact]
        public void Arrange_Returns_Act_Parameters()
        {
            // Arrange
            const string ExpectedValue = "someValue", ActParameter = "expected";

            // Act
            var actBundle = DefineExpected(ExpectedValue)
                .Arrange(expected => ActParameter);

            // Assert
            actBundle.ShouldNotBeNull();
            actBundle.ExpectedValue.ShouldBe(ExpectedValue);
            actBundle.ActParameter.ShouldBe(ActParameter);
        }

        [Fact]
        public void Assert_Action()
        {
            // Arrange
            const string Expected = "expectedValue", Result = "result";
            string expectedValue = null, resultValue = null;

            // Act
            DefineExpected(Expected)
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

        [Fact]
        public void DefineExpected_Returns_Value()
        {
            // Arrange
            var expectedDefinition = new { Value1 = "test", Value2 = "other" };

            // Act
            var definition = DefineExpected(expectedDefinition);

            // Assert
            definition.ShouldBe(expectedDefinition);
        }

        [Fact]
        public void Support_No_DefineExpected()
        {
            // Arrange
            string result = null;

            // Act
            Arrange(() => "paramValue")
                .Act(param => param.ToUpper())
                .Assert(r => result = r);

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void Support_No_DefineExpected_And_No_Arrange()
        {
            // Arrange
            string result = null;

            // Act
            Act(() => "test")
                .Assert(r => result = r);

            // Assert
            result.ShouldNotBeNull();
        }
    }
}
