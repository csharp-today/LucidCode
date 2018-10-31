using Shouldly;
using System;
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
            const string ExpectedResult = "result";

            // Act
            var result = DefineExpected("expectedValue")
                .Arrange(expected => "actParameter")
                .Act(actParameter => ExpectedResult);

            // Assert
            result.ShouldBe(ExpectedResult);
        }

        [Fact]
        public void Arrange_Returns_Act_Parameters()
        {
            // Arrange
            const string ExpectedActParameter = "expected";

            // Act
            var actParameter = DefineExpected("someValue")
                .Arrange(expected => ExpectedActParameter);

            // Assert
            actParameter.ShouldBe(ExpectedActParameter);
        }

        [Fact]
        public void Assert_Action()
        {
            // Arrange
            bool assertionExecuted = false;
            var assertAction = new Action<string>(_ => assertionExecuted = true);

            // Act
            DefineExpected("expectedValue")
                .Arrange(expected => "actParameter")
                .Act(actParameter => "result")
                .Assert(assertAction);

            // Assert
            assertionExecuted.ShouldBeTrue();
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
    }
}
