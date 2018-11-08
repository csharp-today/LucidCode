using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Keeps data for Arrange step
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value</typeparam>
    public class ArrangeManager<TExpectedValue> : ExpectedValueManager<TExpectedValue>
    {
        internal ArrangeManager(TExpectedValue expectedValue) : base(expectedValue) { }

        /// <summary>
        /// Execute Arrange step
        /// </summary>
        /// <typeparam name="TActParam">Type of parameter for Act step. Use anonymous type for multiple values.</typeparam>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>Manager for Act step</returns>
        public ActManager<TExpectedValue, TActParam> Arrange<TActParam>(Func<TExpectedValue, TActParam> arrangeFunc)
        {
            var actParameter = arrangeFunc(ExpectedValue);
            var actBundle = new ActManager<TExpectedValue, TActParam>(ExpectedValue, actParameter);
            return actBundle;
        }
    }
}
