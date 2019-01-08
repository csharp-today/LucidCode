using Xunit;
using LucidCode;

namespace Examples.Extensions
{
    public class ToNullIfEmpty
    {
        [Fact]
        public void Examples_Of_ToNullIfEmpty()
        {
            string value = "abc";
            value = value.ToNullIfEmpty() ?? "default";
            Assert.Equal("abc", value);

            value = "";
            value = value.ToNullIfEmpty() ?? "default";
            Assert.Equal("default", value);

            value = null;
            value = value.ToNullIfEmpty() ?? "default";
            Assert.Equal("default", value);
        }
    }
}
