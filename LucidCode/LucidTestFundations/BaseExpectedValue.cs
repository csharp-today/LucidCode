using System;

namespace LucidCode.LucidTestFundations
{
#pragma warning disable 1591
    public abstract class BaseExpectedValue<TExpectedValue>
#pragma warning restore 1591
    {
        /// <summary>
        /// Expected value that will be used in Assert action
        /// </summary>
        public TExpectedValue ExpectedValue { get; }

        /// <summary>
        /// ExpectedValueCarrier constructor
        /// </summary>
        /// <param name="expectedValue">Expected value that will be used in Assert action</param>
        public BaseExpectedValue(TExpectedValue expectedValue) => ExpectedValue = expectedValue;
    }
}
