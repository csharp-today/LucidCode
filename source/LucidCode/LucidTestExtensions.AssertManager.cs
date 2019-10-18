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
        /// <param name="assertAction">Assert action</param>
        public static async Task AssertAsync<TResult>(this Task<AssertManager<TResult>> manager, Action<TResult> assertAction) =>
            (await manager).Assert(assertAction);
    }
}
