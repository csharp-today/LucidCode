namespace LucidCode
{
    /// <summary>
    /// Support for AAA unit test pattern (Arrange, Act, Assert)
    /// </summary>
    public static class LucidTest
    {
        /// <summary>
        /// Define expected value for the assertion
        /// </summary>
        /// <typeparam name="T">Type of expected object. Use anonymous type for multiple values</typeparam>
        /// <param name="expected">Expected value</param>
        /// <returns>Expected value</returns>
        public static T DefineExpected<T>(T expected) => expected;
    }
}
