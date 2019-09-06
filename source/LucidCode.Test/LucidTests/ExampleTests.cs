using NSubstitute;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public interface INameProvider
    {
        string GetUserName(int id);
    }

    public class ExampleTests
    {
        private readonly INameProvider _nameProvider = Substitute.For<INameProvider>();

        [Fact]
        public void Test_NameProvider() =>
            LucidTest.DefineExpected("FakeName")
            .Arrange(name =>
            {
                const int UserId = 10;
                _nameProvider.GetUserName(UserId).Returns(name);
                return UserId;
            })
            .Act(userId => _nameProvider.GetUserName(userId))
            .Assert((result, expected) => result.ShouldBe(expected));
    }

    public class ExampleTests_Without_LucidTest
    {
        private readonly INameProvider _nameProvider = Substitute.For<INameProvider>();

        [Fact]
        public void Test_NameProvider()
        {
            // Arrange
            const string ExpectedName = "FakeName";
            const int UserId = 10;
            _nameProvider.GetUserName(UserId).Returns(ExpectedName);

            // Act
            var userName = _nameProvider.GetUserName(UserId);

            // Assert
            userName.ShouldBe(ExpectedName);
        }
    }
}
