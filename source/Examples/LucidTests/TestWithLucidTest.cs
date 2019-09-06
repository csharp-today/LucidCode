using LucidCode;
using Shouldly;
using Xunit;

namespace Examples.LucidTests
{
    public class TestWithLucidTest
    {
        [Fact]
        public void Test_NameProvider() => LucidTest
            .Arrange(() => new NameProvider())
            .Act(provider => provider.GetUserName(0))
            .Assert(result => result.ShouldBe("Admin"));
    }
}