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
        /// <typeparam name="T">Type of expected value(s) object. Use anonymous type for multiple values.</typeparam>
        /// <param name="expected">Expected value(s)</param>
        /// <returns>Expected value(s)</returns>
        public static T DefineExpected<T>(T expected) => expected;

        /// <summary>
        /// Gets expected value(s) and prepare all Arrange actions
        /// </summary>
        /// <typeparam name="TExpected">Type of expected value(s)</typeparam>
        /// <typeparam name="TParams">Type of parameter(s) for Act. Use anonymous type for multiple values.</typeparam>
        /// <param name="expected">Expected value(s)</param>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>Act parameter(s)</returns>
        public static TParams Arrange<TExpected, TParams>(this TExpected expected, Func<TExpected, TParams> arrangeFunc) => arrangeFunc(expected);

        /// <summary>
        /// Gets Act parameter(s) and executes Act actions
        /// </summary>
        /// <typeparam name="TParams">Type of parameter(s) for Act</typeparam>
        /// <typeparam name="TResult">Type of result(s). Use anonymous type for multiple values.</typeparam>
        /// <param name="actParameters">Act parameter(s)</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Act result(s)</returns>
        public static TResult Act<TParams, TResult>(this TParams actParameters, Func<TParams, TResult> actFunc) => actFunc(actParameters);

        /// <summary>
        /// Gets Act result(s) and execute Assert actions
        /// </summary>
        /// <typeparam name="TResult">Type of result(s)</typeparam>
        /// <param name="actResult">Act result(s)</param>
        /// <param name="assertAction">Assert action</param>
        public static void Assert<TResult>(this TResult actResult, Action<TResult> assertAction) => assertAction(actResult);
    }
}
