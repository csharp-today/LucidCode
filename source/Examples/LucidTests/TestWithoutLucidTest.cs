using Shouldly;
using Xunit;

namespace Examples.LucidTests
{
    public class TestWithoutLucidTest
    {
        [Fact]
        public void Test_NameProvider()
        {
            // Arrange
            var nameProvider = new NameProvider();

            // Act
            var userName = nameProvider.GetUserName(0);

            // Assert
            userName.ShouldBe("Admin");
        }
    }
}