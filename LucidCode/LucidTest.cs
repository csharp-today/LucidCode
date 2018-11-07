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
        public static ExpectedValueCarrier<TExpectedValue> DefineExpected<TExpectedValue>(TExpectedValue expected) => new ExpectedValueCarrier<TExpectedValue>(expected);

        /// <summary>
        /// Prepare all Arrange actions
        /// </summary>
        /// <param name="arrangeAction">Arrange action</param>
        /// <returns>MissingActParameter that represents no parameter for Act action</returns>
        public static MissingActParameter Arrange(Action arrangeAction)
        {
            arrangeAction();
            return MissingActParameter.Value;
        }

        /// <summary>
        /// Prepare all Arrange actions
        /// </summary>
        /// <typeparam name="TActParam">Type of parameter for Act. Use anonymous type for multiple values.</typeparam>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>Act parameter</returns>
        public static ActParameterCarrier<TActParam> Arrange<TActParam>(Func<TActParam> arrangeFunc) => new ActParameterCarrier<TActParam>(arrangeFunc());

        /// <summary>
        /// Executes Act actions
        /// </summary>
        /// <typeparam name="TResult">Type of result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Act result</returns>
        public static ActResultCarrier<TResult> Act<TResult>(Func<TResult> actFunc) => new ActResultCarrier<TResult>(actFunc());
    }
}
