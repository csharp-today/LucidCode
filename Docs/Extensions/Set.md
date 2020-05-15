# LucidCode

## **Set** extension method

**Description:** Execute action on an item and return the item

Examples:

```csharp
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

```

Unit tests included in the LucidCode library for this extension:

```csharp
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

```
