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
        /// <typeparam name="TActParameter">Type of Act parameter</typeparam>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Act manager</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<AssertManager<TResult>> ActAsync<TActParameter, TResult>(
            this Task<ActManager<TActParameter>> manager,
            Func<TActParameter, TResult> actFunc) =>
            (await manager).Act(actFunc);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="manager">Act manager</param>
        /// <param name="actFunc">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<LightAssertManager> ActAsync<TActParameter>(
            this Task<ActManager<TActParameter>> manager,
            Action<TActParameter> actFunc) =>
            (await manager).Act(actFunc);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="manager">Act manager</param>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<AssertManager<TResult>> ActAsync<TActParameter, TResult>(
            this Task<ActManager<TActParameter>> manager,
            Func<TActParameter, Task<TResult>> actFunc) =>
            await (await manager).ActAsync(actFunc);

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="manager">Act manager</param>
        /// <param name="actFunc">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public static async Task<LightAssertManager> ActAsync<TActParameter>(
            this Task<ActManager<TActParameter>> manager,
            Func<TActParameter, Task> actFunc) =>
            await (await manager).ActAsync(actFunc);
    }
}
