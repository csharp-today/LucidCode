using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Manager for Assert step
    /// </summary>
    public class LightAssertManager
    {
        /// <summary>
        /// Execute Assert step
        /// </summary>
        /// <param name="assertAction">Assert action</param>
        public void Assert(Action assertAction) => assertAction();
    }
}
