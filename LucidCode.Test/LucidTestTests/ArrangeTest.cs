using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTestTests
{
    public class ArrangeTest
    {
        [Fact]
        public void Arrange_Returns_Act_Bundle()
        {
            // Arrange
            const string ExpectedValue = "someValue", ActParameter = "expected";

            // Act
            ActBundle<string, string> actBundle = LucidTest.DefineExpected(ExpectedValue)
                .Arrange(expected => ActParameter);

            // Assert
            actBundle.ShouldNotBeNull();
            actBundle.ExpectedValue.ShouldBe(ExpectedValue);
            actBundle.ActParameter.ShouldBe(ActParameter);
        }

        [Fact]
        public void Arrange_Returns_Act_Parameter()
        {
            // Arrange
            const string ActParameter = "parameter";

            // Act
            ActParameterCarrier<string> actParameter = LucidTest.Arrange(() => ActParameter);

            // Assert
            actParameter.ShouldNotBeNull();
            actParameter.ActParameter.ShouldBe(ActParameter);
        }

        [Fact]
        public void Arrange_Returns_EmptyActParameter()
        {
            // Act
            var returnValue = LucidTest.Arrange(() => { });

            // Assert
            returnValue.ShouldBeOfType<MissingActParameter>();
        }
    }
}
