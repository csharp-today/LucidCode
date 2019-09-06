using LucidCode;
using Xunit;

namespace Examples.Extensions
{
    public class IsNotNull
    {
        [Fact]
        public void Examples_Of_IsNotNull_Extension()
        {
            object obj = new object();
            Assert.True(
                obj.IsNotNull()
                );

            obj = null;
            Assert.False(
                obj.IsNotNull()
                );

            int? integer = 7;
            Assert.True(
                integer.IsNotNull()
                );

            integer = null;
            Assert.False(
                integer.IsNotNull()
                );
        }
    }
}
