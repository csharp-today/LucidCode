using LucidCode.LucidTestFundations;
using System;

namespace LucidCode
{
    /// <summary>
    /// Syntax sugar for AAA unit test pattern (Arrange, Act, Assert)
    /// </summary>
    public static class LucidTest
    {
        /// <summary>
        /// Define expected value for the Assertion
        /// </summary>
        /// <typeparam name="T">Type of expected value object. Use anonymous type for multiple values.</typeparam>
        /// <param name="expected">Expected value</param>
        /// <returns>Expected value</returns>
        public static T DefineExpected<T>(T expected) => expected;

        /// <summary>
        /// Gets expected value and prepare all Arrange actions
        /// </summary>
        /// <typeparam name="TExpected">Type of expected value</typeparam>
        /// <typeparam name="TParams">Type of parameter for Act. Use anonymous type for multiple values.</typeparam>
        /// <param name="expected">Expected value</param>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>ActBundle containing expected value and Act parameter</returns>
        public static ActBundle<TExpected, TParams> Arrange<TExpected, TParams>(this TExpected expected, Func<TExpected, TParams> arrangeFunc)
        {
            var actParameter = arrangeFunc(expected);
            var actBundle = new ActBundle<TExpected, TParams>(expected, actParameter);
            return actBundle;
        }

        /// <summary>
        /// Gets Act parameter and executes Act actions
        /// </summary>
        /// <typeparam name="TExpected">Tpe of expected value</typeparam>
        /// <typeparam name="TParams">Type of parameter for Act</typeparam>
        /// <typeparam name="TResult">Type of result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actParameters">Act bundle</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Act result</returns>
        public static AssertBundle<TExpected, TResult> Act<TExpected, TParams, TResult>(this ActBundle<TExpected, TParams> actParameters, Func<TParams, TResult> actFunc)
        {
            var result = actFunc(actParameters.ActParameter);
            var assertBundle = new AssertBundle<TExpected, TResult>(actParameters.ExpectedValue, result);
            return assertBundle;
        }

        /// <summary>
        /// Gets Act result and execute Assert actions
        /// </summary>
        /// <typeparam name="TExpectedValue">Type of expected value</typeparam>
        /// <typeparam name="TResult">Type of result</typeparam>
        /// <param name="assertBundle">Assert bundle</param>
        /// <param name="assertAction">Assert action</param>
        public static void Assert<TExpectedValue, TResult>(this AssertBundle<TExpectedValue, TResult> assertBundle, Action<TResult, TExpectedValue> assertAction) => assertAction(assertBundle.ActResult, assertBundle.ExpectedValue);
    }
}
