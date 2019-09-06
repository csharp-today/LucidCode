using LucidCode;
using Shouldly;
using Xunit;

namespace Examples.LucidTests
{
    public class AdvancedTestsWithLucidTest
    {
        [Fact]
        public void Test_Admin_User() => LucidTest
            .Arrange(CreateNameProvider)
            .Act(provider => provider.GetUserName(0))
            .Assert(result => result.ShouldBe("Admin"));

        [Fact]
        public void Test_Boss_User() => LucidTest
            .Arrange(CreateNameProvider)
            .Act(provider => provider.GetUserName(1))
            .Assert(result => result.ShouldBe("Boss"));

        [Fact]
        public void Test_Complex_Case() => LucidTest
            .DefineExpected(new
            {
                UserName = "PowerUser",
                UserId = 123,
                SomeOtherNeededValue = "I love tests!"
            })
            .Arrange(expected =>
            {
                var provider = CreateNameProvider();

                /* More provider setup logic here
                 * Can use any value defined in 'DefineExpected'
                 */

                return new
                {
                    Provider = provider,
                    expected.UserId
                };
            })
            .Act(param =>
            {
                var result = param.Provider.GetUserName(param.UserId);
                
                /*
                 * Here put more Act things
                 */

                return result;
            })
            .Assert((expected, result) =>
            {
                /* Do advanced asserts using defined
                 * expected values and result
                 */
            });

        private INameProvider CreateNameProvider() => new NameProvider();
    }
}