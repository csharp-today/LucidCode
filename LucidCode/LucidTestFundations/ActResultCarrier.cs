using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Result of Act action
    /// </summary>
    /// <typeparam name="TResult">Type of Act result</typeparam>
    public class ActResultCarrier<TResult>
    {
        /// <summary>
        /// Act result
        /// </summary>
        public TResult ActResult { get; }

        /// <summary>
        /// ActResultCarrier constructor
        /// </summary>
        /// <param name="actResult">Act result value</param>
        public ActResultCarrier(TResult actResult) => ActResult = actResult;

        /// <summary>
        /// Gets Act result and execute Assert actions
        /// </summary>
        /// <param name="assertAction">Assert action</param>
        public void Assert(Action<TResult> assertAction) => assertAction(ActResult);
    }
}
