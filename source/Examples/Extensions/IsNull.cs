using LucidCode;
using Xunit;

namespace Examples.Extensions
{
    public class IsNull
    {
        [Fact]
        public void Examples_Of_IsNull_Extension()
        {
            object obj = null;
            Assert.True(
                obj.IsNull()
                );

            obj = new object();
            Assert.False(
                obj.IsNull()
                );

            int? integer = null;
            Assert.True(
                integer.IsNull()
                );

            integer = 7;
            Assert.False(
                integer.IsNull()
                );
        }
    }
}
