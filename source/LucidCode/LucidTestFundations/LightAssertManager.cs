using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Manager for Assert step
    /// </summary>
    public class LightAssertManager
    {
        /// <summary>
        /// Execute Assert step
        /// </summary>
        /// <param name="assertAction">Assert action</param>
        public void Assert(Action assertAction) => assertAction();
    }

    /// <summary>
    /// Manager for Assert step
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value for Arrange and Assert steps</typeparam>
    public class LightAssertManager<TExpectedValue> : ExpectedValueManager<TExpectedValue>
    {
        internal LightAssertManager(TExpectedValue expectedValue) : base(expectedValue) { }

        /// <summary>
        /// Execute Assert step
        /// </summary>
        /// <param name="assertAction">Assert action</param>
        public void Assert(Action<TExpectedValue> assertAction) => assertAction(ExpectedValue);
    }
}
