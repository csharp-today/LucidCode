namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Manager for Act step
    /// </summary>
    public class LightActManager
    {
    }

    /// <summary>
    /// Manager for Act step
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value for Arrange and Assert steps</typeparam>
    public class LightActManager<TExpectedValue> : ExpectedValueManager<TExpectedValue>
    {
        internal LightActManager(TExpectedValue expectedValue) : base(expectedValue) { }
    }
}
