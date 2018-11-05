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
        /// <typeparam name="TExpectedValue">Type of expected value object. Use anonymous type for multiple values.</typeparam>
        /// <param name="expected">Expected value</param>
        /// <returns>Expected value</returns>
        public static TExpectedValue DefineExpected<TExpectedValue>(TExpectedValue expected) => expected;

        /// <summary>
        /// Prepare all Arrange actions
        /// </summary>
        /// <typeparam name="TActParam">Type of parameter for Act. Use anonymous type for multiple values.</typeparam>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>Act parameter</returns>
        public static TActParam Arrange<TActParam>(Func<TActParam> arrangeFunc) => arrangeFunc();

        /// <summary>
        /// Gets expected value and prepare all Arrange actions
        /// </summary>
        /// <typeparam name="TExpectedValue">Type of expected value</typeparam>
        /// <typeparam name="TActParam">Type of parameter for Act. Use anonymous type for multiple values.</typeparam>
        /// <param name="expectedValue">Expected value</param>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>ActBundle containing expected value and Act parameter</returns>
        public static ActBundle<TExpectedValue, TActParam> Arrange<TExpectedValue, TActParam>(this TExpectedValue expectedValue, Func<TExpectedValue, TActParam> arrangeFunc)
        {
            var actParameter = arrangeFunc(expectedValue);
            var actBundle = new ActBundle<TExpectedValue, TActParam>(expectedValue, actParameter);
            return actBundle;
        }

        /// <summary>
        /// Executes Act actions
        /// </summary>
        /// <typeparam name="TResult">Type of result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Act result</returns>
        public static TResult Act<TResult>(Func<TResult> actFunc) => actFunc();

        /// <summary>
        /// Gets Act parameter and executes Act actions
        /// </summary>
        /// <typeparam name="TActParam">Type of Act parameter</typeparam>
        /// <typeparam name="TResult">Type of result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actParam">Act parameter</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Act result</returns>
        public static TResult Act<TActParam, TResult>(this TActParam actParam, Func<TActParam, TResult> actFunc) => actFunc(actParam);

        /// <summary>
        /// Gets Act result and execute Assert actions
        /// </summary>
        /// <typeparam name="TResult">Type of Act result</typeparam>
        /// <param name="actResult">Act result</param>
        /// <param name="assertAction">Assert action</param>
        public static void Assert<TResult>(this TResult actResult, Action<TResult> assertAction) => assertAction(actResult);
    }
}
