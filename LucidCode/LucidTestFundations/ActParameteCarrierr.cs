using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Parameter for Act action
    /// </summary>
    /// <typeparam name="TActParameter">Type of Act parameter</typeparam>
    public class ActParameterCarrier<TActParameter>
    {
        /// <summary>
        /// Act parameter value
        /// </summary>
        public TActParameter ActParameter { get; }

        /// <summary>
        /// ActParameterCarrier constructor
        /// </summary>
        /// <param name="actParameter">Act parameter value</param>
        public ActParameterCarrier(TActParameter actParameter) => ActParameter = actParameter;

        /// <summary>
        /// Gets Act parameter and executes Act actions
        /// </summary>
        /// <typeparam name="TResult">Type of result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Act result</returns>
        public ActResultCarrier<TResult> Act<TResult>(Func<TActParameter, TResult> actFunc) => new ActResultCarrier<TResult>(actFunc(ActParameter));
    }
}
