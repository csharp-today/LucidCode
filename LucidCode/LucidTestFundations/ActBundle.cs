namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Bundle for Act action
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value that will be used in Assert action</typeparam>
    /// <typeparam name="TActParameter">Type of Act parameter</typeparam>
    public class ActBundle<TExpectedValue, TActParameter> : ExpectedValueCarrier<TExpectedValue>
    {
        /// <summary>
        /// Act parameter
        /// </summary>
        public TActParameter ActParameter { get; }

        /// <summary>
        /// ActBundle constructor
        /// </summary>
        /// <param name="expectedValue">Expected value that will be used in Assert action</param>
        /// <param name="actParameter">Act parameter</param>
        public ActBundle(TExpectedValue expectedValue, TActParameter actParameter)
            : base(expectedValue) => ActParameter = actParameter;
    }
}
