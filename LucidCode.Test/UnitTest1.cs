using System;
using Xunit;

namespace LucidCode.Test
{
    public class UnitTest1
    {
        [Fact]
        public void FailingTest()
        {
            throw new Exception("TEST");
        }
    }
}
