using LucidCode;
using Xunit;

namespace Examples.Extensions
{
    public class Set
    {
        private class MyType
        {
            public bool Executed { get; private set; } = false;

            public void MarkAsExecuted() => Executed = true;
            public void DoMore() { }
        }

        [Fact]
        public void Example_Of_Set_Extension()
        {
            MyType myType1 = new MyType();
            MyType myType2 = myType1.Set(t => t.MarkAsExecuted());
            Assert.True(myType1 == myType2);
            Assert.True(myType1.Executed);

            // The idea is to use the extension
            // is to create and set object inline
            var myType = new MyType()
                .Set(t => t.MarkAsExecuted())
                .Set(t => t.DoMore());
        }
    }
}
