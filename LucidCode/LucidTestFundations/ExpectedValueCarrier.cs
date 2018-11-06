using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Carrier of the expected value that will be used in Assert action
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value</typeparam>
    public class ExpectedValueCarrier<TExpectedValue> : BaseExpectedValue<TExpectedValue>
    {
#pragma warning disable 1591
        public ExpectedValueCarrier(TExpectedValue expectedValue) : base(expectedValue) { }
#pragma warning restore 1591

        /// <summary>
        /// Gets expected value and prepare all Arrange actions
        /// </summary>
        /// <typeparam name="TActParam">Type of parameter for Act. Use anonymous type for multiple values.</typeparam>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>ActBundle containing expected value and Act parameter</returns>
        public ActBundle<TExpectedValue, TActParam> Arrange<TActParam>(Func<TExpectedValue, TActParam> arrangeFunc)
        {
            var actParameter = arrangeFunc(ExpectedValue);
            var actBundle = new ActBundle<TExpectedValue, TActParam>(ExpectedValue, actParameter);
            return actBundle;
        }
    }
}
