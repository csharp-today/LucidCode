using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Keeps expected value for Arrange and Assert steps
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value. Use anonymous type for multiple values.</typeparam>
    public abstract class ExpectedValueManager<TExpectedValue>
    {
        /// <summary>
        /// Expected value for Arrange and Assert steps
        /// </summary>
        public TExpectedValue ExpectedValue { get; }

        internal ExpectedValueManager(TExpectedValue expectedValue) => ExpectedValue = expectedValue;
    }
}
