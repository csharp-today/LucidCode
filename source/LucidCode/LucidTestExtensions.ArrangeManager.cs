using LucidCode.LucidTestFundations;
using System;
using System.Threading.Tasks;

namespace LucidCode
{
    public static partial class LucidTestExtensions
    {
        /// <summary>
        /// Execute Arrange step
        /// </summary>
        /// <param name="manager">Arrange manager</param>
        /// <param name="arrangeAction">Arrange action</param>
        /// <returns>Manager for Act step</returns>
        public static async Task<LightActManager<TExpectedValue>> ArrangeAsync<TExpectedValue>(
            this Task<ArrangeManager<TExpectedValue>> manager,
            Action<TExpectedValue> arrangeAction) =>
            (await manager).Arrange(arrangeAction);

        /// <summary>
        /// Execute Arrange step
        /// </summary>
        /// <typeparam name="TActParam">Type of parameter for Act step. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Arrange manager</param>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>Manager for Act step</returns>
        public static async Task<ActManager<TExpectedValue, TActParam>> ArrangeAsync<TExpectedValue, TActParam>(
            this Task<ArrangeManager<TExpectedValue>> manager,
            Func<TExpectedValue, TActParam> arrangeFunc) =>
            (await manager).Arrange(arrangeFunc);


        /// <summary>
        /// Execute Arrange step
        /// </summary>
        /// <param name="manager">Arrange manager</param>
        /// <param name="arrangeAction">Arrange action</param>
        /// <returns>Manager for Act step</returns>
        public static async Task<LightActManager<TExpectedValue>> ArrangeAsync<TExpectedValue>(
            this Task<ArrangeManager<TExpectedValue>> manager,
            Func<TExpectedValue, Task> arrangeAction) =>
            await (await manager).ArrangeAsync(arrangeAction);

        /// <summary>
        /// Execute Arrange step
        /// </summary>
        /// <typeparam name="TActParam">Type of parameter for Act step. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Arrange manager</param>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>Manager for Act step</returns>
        public static async Task<ActManager<TExpectedValue, TActParam>> ArrangeAsync<TExpectedValue, TActParam>(
            this Task<ArrangeManager<TExpectedValue>> manager,
            Func<TExpectedValue, Task<TActParam>> arrangeFunc) =>
            await (await manager).ArrangeAsync(arrangeFunc);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="manager">Arrange manager</param>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<LightAssertManager<TExpectedValue>> ActAsync<TExpectedValue>(
            this Task<ArrangeManager<TExpectedValue>> manager,
            Action actAction) =>
            (await manager).Act(actAction);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TActResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Arrange manager</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<AssertManager<TExpectedValue, TActResult>> ActAsync<TExpectedValue, TActResult>(
            this Task<ArrangeManager<TExpectedValue>> manager,
            Func<TActResult> actFunc) =>
            (await manager).Act(actFunc);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="manager">Arrange manager</param>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<LightAssertManager<TExpectedValue>> ActAsync<TExpectedValue>(
            this Task<ArrangeManager<TExpectedValue>> manager,
            Func<Task> actAction) =>
            await (await manager).ActAsync(actAction);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TActResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Arrange manager</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<AssertManager<TExpectedValue, TActResult>> ActAsync<TExpectedValue, TActResult>(
            this Task<ArrangeManager<TExpectedValue>> manager,
            Func<Task<TActResult>> actFunc) =>
            await (await manager).ActAsync(actFunc);
    }
}
