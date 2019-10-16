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
        /// <param name="manager">Assert manager</param>
        /// <param name="assertAction">Assert action</param>
        public static async Task AssertAsync(this Task<LightAssertManager> manager, Action assertAction) =>
            (await manager).Assert(assertAction);
    }
}
