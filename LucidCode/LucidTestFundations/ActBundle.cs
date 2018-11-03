using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Bundle for Act action
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value that will be used in Assert action</typeparam>
    /// <typeparam name="TActParameter">Type of Act parameter</typeparam>
    public class ActBundle<TExpectedValue, TActParameter> : ExpectedValueCarrier<TExpectedValue>
    {
        /// <summary>
        /// Act parameter
        /// </summary>
        public TActParameter ActParameter { get; }

        /// <summary>
        /// ActBundle constructor
        /// </summary>
        /// <param name="expectedValue">Expected value that will be used in Assert action</param>
        /// <param name="actParameter">Act parameter</param>
        public ActBundle(TExpectedValue expectedValue, TActParameter actParameter)
            : base(expectedValue) => ActParameter = actParameter;

        /// <summary>
        /// Gets Act parameter and executes Act actions
        /// </summary>
        /// <typeparam name="TResult">Type of result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Assert bundle with expected value and result</returns>
        public AssertBundle<TExpectedValue, TResult> Act<TResult>(Func<TActParameter, TResult> actFunc)
        {
            var result = actFunc(ActParameter);
            var assertBundle = new AssertBundle<TExpectedValue, TResult>(ExpectedValue, result);
            return assertBundle;
        }
    }
}
