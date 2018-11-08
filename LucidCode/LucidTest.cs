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
        /// Define expected value for Arrange and Assert steps
        /// </summary>
        /// <typeparam name="TExpectedValue">Type of expected value object. Use anonymous type for multiple values.</typeparam>
        /// <param name="expected">Expected value</param>
        /// <returns>Manager for Arrange step</returns>
        public static ArrangeManager<TExpectedValue> DefineExpected<TExpectedValue>(TExpectedValue expected) => new ArrangeManager<TExpectedValue>(expected);

        /// <summary>
        /// Execute Arrange step
        /// </summary>
        /// <param name="arrangeAction">Arrange action</param>
        /// <returns>Manager for Act step</returns>
        public static LightActManager Arrange(Action arrangeAction)
        {
            arrangeAction();
            return new LightActManager();
        }

        /// <summary>
        /// Execute Arrange step
        /// </summary>
        /// <typeparam name="TActParam">Type of parameter for Act step. Use anonymous type for multiple values.</typeparam>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>Manager for Act step</returns>
        public static ActManager<TActParam> Arrange<TActParam>(Func<TActParam> arrangeFunc) => new ActManager<TActParam>(arrangeFunc());

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static AssertManager<TResult> Act<TResult>(Func<TResult> actFunc) => new AssertManager<TResult>(actFunc());
    }
}
