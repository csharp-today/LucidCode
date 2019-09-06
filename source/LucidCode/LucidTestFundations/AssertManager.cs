using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Manager for Assert step
    /// </summary>
    /// <typeparam name="TResult">Type of Act result</typeparam>
    public class AssertManager<TResult>
    {
        /// <summary>
        /// Act result
        /// </summary>
        public TResult ActResult { get; }

        internal AssertManager(TResult actResult) => ActResult = actResult;

        /// <summary>
        /// Execute Assert step
        /// </summary>
        /// <param name="assertAction">Assert action</param>
        public void Assert(Action<TResult> assertAction) => assertAction(ActResult);
    }

    /// <summary>
    /// Manager for Assert step
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value</typeparam>
    /// <typeparam name="TResult">Type of Act result</typeparam>
    public class AssertManager<TExpectedValue, TResult> : ExpectedValueManager<TExpectedValue>
    {
        /// <summary>
        /// Act result
        /// </summary>
        public TResult ActResult { get; }

        internal AssertManager(TExpectedValue expectedValue, TResult result)
            : base(expectedValue) => ActResult = result;

        /// <summary>
        /// Execute Assert step
        /// </summary>
        /// <param name="assertAction">Assert action</param>
        public void Assert(Action<TExpectedValue, TResult> assertAction) => assertAction(ExpectedValue, ActResult);
    }
}
