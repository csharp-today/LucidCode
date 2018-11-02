namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Carrier of the expected value that will be used in Assert action
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value</typeparam>
    public class ExpectedValueCarrier<TExpectedValue>
    {
        /// <summary>
        /// Expected value that will be used in Assert action
        /// </summary>
        public TExpectedValue ExpectedValue { get; }

        /// <summary>
        /// ExpectedValueCarrier constructor
        /// </summary>
        /// <param name="expectedValue">Expected value that will be used in Assert action</param>
        public ExpectedValueCarrier(TExpectedValue expectedValue) => ExpectedValue = expectedValue;
    }
}
