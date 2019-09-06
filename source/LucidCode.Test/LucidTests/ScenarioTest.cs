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
            LucidTest.Arrange(() => { })
                .Act(() => ExpectedActResult)
                .Assert(result => actResult = result);

            // Assert
            actResult.ShouldBe(ExpectedActResult);
        }

        [Fact]
        public void AAA_Without_Act_Parameter_And_Result()
        {
            // Arrange
            bool arrangeExecutedFine = false, actExecutedFine = false, assertExecutedFine = false;

            // Act
            LucidTest.Arrange(() => { arrangeExecutedFine = true; })
                .Act(() => { actExecutedFine = true; })
                .Assert(() => { assertExecutedFine = true; });

            // Assert
            arrangeExecutedFine.ShouldBeTrue();
            actExecutedFine.ShouldBeTrue();
            assertExecutedFine.ShouldBeTrue();
        }

        [Fact]
        public void AAA_Without_Act_Result()
        {
            // Arrange
            bool executedAct = false, executedAssert = false;

            // Act
            LucidTest.Arrange(() => ExpectedActParam)
                .Act(p => { executedAct = p == ExpectedActParam; })
                .Assert(() => executedAssert = true);

            // Assert
            executedAct.ShouldBeTrue();
            executedAssert.ShouldBeTrue();
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
        public void Act_Assert_Without_Act_Result()
        {
            // Arrange
            bool actExecutedFine = false, assertExecutedFine = false;

            // Act
            LucidTest.Act(() => { actExecutedFine = true; })
                .Assert(() => { assertExecutedFine = true; });

            // Assert
            actExecutedFine.ShouldBeTrue();
            assertExecutedFine.ShouldBeTrue();
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
                .Assert((expected, result) =>
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
            string actResult = null, expectedValue = null;

            // Act
            LucidTest.DefineExpected(ExpectedValue)
                .Arrange(_ => { })
                .Act(() => ExpectedActResult)
                .Assert((expected, result) =>
                {
                    expectedValue = expected;
                    actResult = result;
                });

            // Assert
            expectedValue.ShouldBe(ExpectedValue);
            actResult.ShouldBe(ExpectedActResult);
        }

        [Fact]
        public void ExpectedValueAAA_Without_Act_Parameter_And_Result()
        {
            // Arrange
            bool arrangeExecutedFine = false, actExecutedFine = false, assertExecutedFine = false;

            // Act
            LucidTest.DefineExpected(ExpectedValue)
                .Arrange(expected => { arrangeExecutedFine = expected == ExpectedValue; })
                .Act(() => { actExecutedFine = true; })
                .Assert(expected => { assertExecutedFine = expected == ExpectedValue; });

            // Assert
            arrangeExecutedFine.ShouldBeTrue();
            actExecutedFine.ShouldBeTrue();
            assertExecutedFine.ShouldBeTrue();
        }

        [Fact]
        public void ExpectedValueAAA_Without_Act_Result()
        {
            // Arrange
            bool actExecutedFine = false, assertExecutedFine = false;

            // Act
            LucidTest.DefineExpected(ExpectedValue)
                .Arrange(value => value == ExpectedValue ? ExpectedActParam : "")
                .Act(param => { actExecutedFine = param == ExpectedActParam; })
                .Assert(expected => { assertExecutedFine = expected == ExpectedValue; });

            // Assert
            actExecutedFine.ShouldBeTrue();
            assertExecutedFine.ShouldBeTrue();
        }

        [Fact]
        public void ExpectedValue_Act_Assert()
        {
            // Arrange
            string expectedValue = null, actResult = null;

            // Act
            LucidTest.DefineExpected(ExpectedValue)
                .Act(() => ExpectedActResult)
                .Assert((expected, result) =>
                {
                    actResult = result;
                    expectedValue = expected;
                });

            // Assert
            expectedValue.ShouldBe(ExpectedValue);
            actResult.ShouldBe(ExpectedActResult);
        }

        [Fact]
        public void ExpectedValue_Act_Assert_Without_Act_Result()
        {
            // Arrange
            bool actExecutedFine = false, assertExecutedFine = false;

            // Act
            LucidTest.DefineExpected(ExpectedValue)
                .Act(() => { actExecutedFine = true; })
                .Assert(expected => { assertExecutedFine = expected == ExpectedValue; });

            // Assert
            actExecutedFine.ShouldBeTrue();
            assertExecutedFine.ShouldBeTrue();
        }
    }
}
