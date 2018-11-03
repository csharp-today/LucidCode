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
        /// <typeparam name="TExpected">Type of expected value object. Use anonymous type for multiple values.</typeparam>
        /// <param name="expected">Expected value</param>
        /// <returns>Expected value</returns>
        public static TExpected DefineExpected<TExpected>(TExpected expected) => expected;

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
    }
}
