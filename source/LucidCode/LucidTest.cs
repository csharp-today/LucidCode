using LucidCode.LucidTestFundations;
using System;
using System.Threading.Tasks;

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
        /// Define expected value for Arrange and Assert steps
        /// </summary>
        /// <typeparam name="TExpectedValue">Type of expected value object. Use anonymous type for multiple values.</typeparam>
        /// <param name="expectedFunc">Function returning expected value</param>
        /// <returns>Manager for Arrange step</returns>
        public static ArrangeManager<TExpectedValue> DefineExpected<TExpectedValue>(Func<TExpectedValue> expectedFunc) => DefineExpected<TExpectedValue>(expectedFunc());

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
        /// Execute Arrange step asynchronously
        /// </summary>
        /// <param name="arrangeAction">Arrange function</param>
        /// <returns>Manager for Act step</returns>
        public static async Task<LightActManager> ArrangeAsync(Func<Task> arrangeAction)
        {
            await arrangeAction();
            return new LightActManager();
        }

        /// <summary>
        /// Execute Arrange step asynchronously
        /// </summary>
        /// <typeparam name="TActParam">Type of parameter for Act step. Use anonymous type for multiple values.</typeparam>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>Manager for Act step</returns>
        public static async Task<ActManager<TActParam>> ArrangeAsync<TActParam>(Func<Task<TActParam>> arrangeFunc)
        {
            var actParameter = await arrangeFunc();
            return new ActManager<TActParam>(actParameter);
        }

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static LightAssertManager Act(Action actAction)
        {
            actAction();
            var manager = new LightAssertManager();
            return manager;
        }

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static AssertManager<TResult> Act<TResult>(Func<TResult> actFunc) => new AssertManager<TResult>(actFunc());

        /// <summary>
        /// Execute Act step asynchronously
        /// </summary>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<LightAssertManager> ActAsync(Func<Task> actAction)
        {
            await actAction();
            return new LightAssertManager();
        }

        /// <summary>
        /// Execute Act step asynchronously
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<AssertManager<TResult>> ActAsync<TResult>(Func<Task<TResult>> actFunc)
        {
            var assertParameter = await actFunc();
            return new AssertManager<TResult>(assertParameter);
        }
    }
}
