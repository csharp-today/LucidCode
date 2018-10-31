namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Bundle for Act action
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value that will be used in Assert action</typeparam>
    /// <typeparam name="TActParameter">Type of Act parameter</typeparam>
    public class ActBundle<TExpectedValue, TActParameter>
    {
        /// <summary>
        /// Act parameter
        /// </summary>
        public TActParameter ActParameter { get; }

        /// <summary>
        /// Expected value that will be used in Assert action
        /// </summary>
        public TExpectedValue ExpectedValue { get; }

        /// <summary>
        /// ActBundle constructor
        /// </summary>
        /// <param name="expectedValue">Expected value that will be used in Assert action</param>
        /// <param name="actParameter">Act parameter</param>
        public ActBundle(TExpectedValue expectedValue, TActParameter actParameter)
        {
            ExpectedValue = expectedValue;
            ActParameter = actParameter;
        }
    }
}
