using LucidCode.LucidTestFundations;
using System;
using System.Threading.Tasks;

namespace LucidCode
{
    public static partial class LucidTestExtensions
    {
        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="manager">Light Act manager</param>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<LightAssertManager<TExpectedValue>> ActAsync<TExpectedValue>(
            this Task<LightActManager<TExpectedValue>> manager,
            Action actAction) =>
            (await manager).Act(actAction);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Light Act manager</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<AssertManager<TExpectedValue, TResult>> ActAsync<TExpectedValue, TResult>(
            this Task<LightActManager<TExpectedValue>> manager,
            Func<TResult> actFunc) =>
            (await manager).Act(actFunc);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="manager">Light Act manager</param>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<LightAssertManager<TExpectedValue>> ActAsync<TExpectedValue>(
            this Task<LightActManager<TExpectedValue>> manager,
            Func<Task> actAction) =>
            await (await manager).ActAsync(actAction);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Light Act manager</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<AssertManager<TExpectedValue, TResult>> ActAsync<TExpectedValue, TResult>(
            this Task<LightActManager<TExpectedValue>> manager,
            Func<Task<TResult>> actFunc) =>
            await (await manager).ActAsync(actFunc);
    }
}
