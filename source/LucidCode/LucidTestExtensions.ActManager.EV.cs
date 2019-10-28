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
        /// <param name="manager">Act manager</param>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<LightAssertManager<TExpectedValue>> ActAsync<TExpectedValue, TActParameter>(
            this Task<ActManager<TExpectedValue, TActParameter>> manager,
            Action<TActParameter> actAction) =>
            (await manager).Act(actAction);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Act manager</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<AssertManager<TExpectedValue, TResult>> ActAsync<TExpectedValue, TResult, TActParameter>(
            this Task<ActManager<TExpectedValue, TActParameter>> manager,
            Func<TActParameter, TResult> actFunc) =>
            (await manager).Act(actFunc);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="manager">Act manager</param>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<LightAssertManager<TExpectedValue>> ActAsync<TExpectedValue, TActParameter>(
            this Task<ActManager<TExpectedValue, TActParameter>> manager,
            Func<TActParameter, Task> actAction) =>
            await (await manager).ActAsync(actAction);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Act manager</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<AssertManager<TExpectedValue, TResult>> ActAsync<TExpectedValue, TResult, TActParameter>(
            this Task<ActManager<TExpectedValue, TActParameter>> manager,
            Func<TActParameter, Task<TResult>> actFunc) =>
            await (await manager).ActAsync(actFunc);
    }
}
