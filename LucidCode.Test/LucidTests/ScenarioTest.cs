using Shouldly;
using System;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class ScenarioTest
    {
        private const string ExpectedValue = "value",
            ExpectedActParam = "param",
            ExpectedActResult = "result";

        // Temporary work-around to keep track of all scenarios.
        // Don't want to break CI pipeline because of not implemented scenarios.
        // Switch to true for local development to see outstanding work.
        private readonly bool ThrowErrorsForNotImplementedScenarios = false;

        [Fact]
        public void AAA()
        {
            // Arrange
            string actResult = null;

            // Act
            LucidTest.Arrange(() => ExpectedActParam)
                .Act(param => param == ExpectedActParam ? ExpectedActResult : "")
                .Assert(result => actResult = result);

            // Assert
            actResult.ShouldBe(ExpectedActResult);
        }

        [Fact]
        public void AAA_Without_Act_Parameter()
        {
            // Arrange
            string actResult = null;

            // Act
            LucidTest.Arrange(() => { });
            NotImplemented();
        }

        [Fact]
        public void AAA_Without_Act_Result()
        {
            // Arrange
            bool executedAct = false, executedAssert = false;

            // Act
            LucidTest.Arrange(() => ExpectedActParam);
            NotImplemented();
        }

        [Fact]
        public void Act_Assert()
        {
            // Arrange
            string actResult = null;

            // Act
            LucidTest.Act(() => ExpectedActResult)
                .Assert(result => actResult = result);

            // Assert
            actResult.ShouldBe(ExpectedActResult);
        }

        [Fact]
        public void ExpectedValueAAA()
        {
            // Arrange
            string expectedValue = null,
                actResult = null;

            // Act
            LucidTest.DefineExpected(ExpectedValue)
                .Arrange(expected => expected == ExpectedValue ? ExpectedActParam : "")
                .Act(param => param == ExpectedActParam ? ExpectedActResult : "")
                .Assert((result, expected) =>
                {
                    expectedValue = expected;
                    actResult = result;
                });

            // Assert
            expectedValue.ShouldBe(ExpectedValue);
            actResult.ShouldBe(ExpectedActResult);
        }

        [Fact]
        public void ExpectedValueAAA_Without_Act_Parameter()
        {
            // Arrange
            string actResult = null;

            // Act
            LucidTest.DefineExpected(ExpectedValue);
            NotImplemented();
        }

        [Fact]
        public void ExpectedValueAAA_Without_Act_Result()
        {
            // Act
            LucidTest.DefineExpected(ExpectedValue)
                .Arrange(value => value == ExpectedValue ? ExpectedActParam : "");
            NotImplemented();
        }

        [Fact]
        public void ExpectedValue_Act_Assert()
        {
            // Arrange
            string actResult = null;

            // Act
            LucidTest.DefineExpected(ExpectedValue);
            NotImplemented();
        }

        private void NotImplemented()
        {
            if (ThrowErrorsForNotImplementedScenarios)
            {
                throw new NotImplementedException();
            }
        }
    }
}
