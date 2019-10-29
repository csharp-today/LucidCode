using LucidCode.LucidTestFundations;
using System;
using System.Threading.Tasks;

namespace LucidCode
{
    public static partial class LucidTestExtensions
    {
        /// <summary>
        /// Execute Assert step
        /// </summary>
        /// <param name="manager">Light Assert manager</param>
        /// <param name="assertAction">Assert action</param>
        public static async Task AssertAsync<TExpectedValue>(
            this Task<LightAssertManager<TExpectedValue>> manager,
            Action<TExpectedValue> assertAction) =>
            (await manager).Assert(assertAction);

        /// <summary>
        /// Execute Assert step
        /// </summary>
        /// <param name="manager">Light Assert manager</param>
        /// <param name="assertAction">Assert action</param>
        public static async Task AssertAsync<TExpectedValue>(
            this Task<LightAssertManager<TExpectedValue>> manager,
            Func<TExpectedValue, Task> assertAction) =>
            await (await manager).AssertAsync(assertAction);
    }
}
