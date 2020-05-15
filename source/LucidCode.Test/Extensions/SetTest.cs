using Shouldly;
using Xunit;

namespace LucidCode.Test.Extensions
{
    public class SetTest
    {
        [Fact]
        public void Return_The_Same_Object() => LucidTest
            .DefineExpected("value")
            .Arrange(p => p)
            .Act(value => value.Set(_ => { }))
            .Assert((expectedValue, value) => value.ShouldBe(expectedValue));

        [Fact]
        public void Set_Action_Is_Executed() => LucidTest
            .Act(() =>
            {
                var isExecuted = false;
                "value".Set(_ => isExecuted = true);
                return isExecuted;
            })
            .Assert(isExecuted => isExecuted.ShouldBeTrue());
    }
}
