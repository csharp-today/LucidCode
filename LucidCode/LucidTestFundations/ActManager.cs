using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Manager for Act step
    /// </summary>
    /// <typeparam name="TActParameter">Type of parameter for Act step</typeparam>
    public class ActManager<TActParameter>
    {
        /// <summary>
        /// Act parameter
        /// </summary>
        public TActParameter ActParameter { get; }

        internal ActManager(TActParameter actParameter) => ActParameter = actParameter;

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public AssertManager<TResult> Act<TResult>(Func<TActParameter, TResult> actFunc) => new AssertManager<TResult>(actFunc(ActParameter));
    }

    /// <summary>
    /// Manager for Act step
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value for Assert step</typeparam>
    /// <typeparam name="TActParameter">Type of parameter for Act step</typeparam>
    public class ActManager<TExpectedValue, TActParameter> : ExpectedValueManager<TExpectedValue>
    {
        /// <summary>
        /// Act parameter
        /// </summary>
        public TActParameter ActParameter { get; }

        internal ActManager(TExpectedValue expectedValue, TActParameter actParameter)
            : base(expectedValue) => ActParameter = actParameter;

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public AssertManager<TExpectedValue, TResult> Act<TResult>(Func<TActParameter, TResult> actFunc)
        {
            var result = actFunc(ActParameter);
            var assertBundle = new AssertManager<TExpectedValue, TResult>(ExpectedValue, result);
            return assertBundle;
        }
    }
}
