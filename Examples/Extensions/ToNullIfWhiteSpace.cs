using Xunit;
using LucidCode;

namespace Examples.Extensions
{
    public class ToNullIfWhiteSpace
    {
        [Fact]
        public void Examples_Of_ToNullIfWhiteSpace()
        {
            string value = "abc";
            value = value.ToNullIfWhiteSpace() ?? "default";
            Assert.Equal("abc", value);

            value = "   ";
            value = value.ToNullIfWhiteSpace() ?? "default";
            Assert.Equal("default", value);

            value = "";
            value = value.ToNullIfWhiteSpace() ?? "default";
            Assert.Equal("default", value);

            value = null;
            value = value.ToNullIfWhiteSpace() ?? "default";
            Assert.Equal("default", value);
        }
    }
}
