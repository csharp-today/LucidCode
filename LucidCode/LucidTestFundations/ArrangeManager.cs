using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Keeps data for Arrange step
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value</typeparam>
    public class ArrangeManager<TExpectedValue> : ExpectedValueManager<TExpectedValue>
    {
        internal ArrangeManager(TExpectedValue expectedValue) : base(expectedValue) { }

        /// <summary>
        /// Execute Arrange step
        /// </summary>
        /// <param name="arrangeAction">Arrange action</param>
        /// <returns>Manager for Act step</returns>
        public LightActManager<TExpectedValue> Arrange(Action<TExpectedValue> arrangeAction)
        {
            arrangeAction(ExpectedValue);
            var manager = new LightActManager<TExpectedValue>(ExpectedValue);
            return manager;
        }

        /// <summary>
        /// Execute Arrange step
        /// </summary>
        /// <typeparam name="TActParam">Type of parameter for Act step. Use anonymous type for multiple values.</typeparam>
        /// <param name="arrangeFunc">Arrange function</param>
        /// <returns>Manager for Act step</returns>
        public ActManager<TExpectedValue, TActParam> Arrange<TActParam>(Func<TExpectedValue, TActParam> arrangeFunc)
        {
            var actParameter = arrangeFunc(ExpectedValue);
            var manager = new ActManager<TExpectedValue, TActParam>(ExpectedValue, actParameter);
            return manager;
        }

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public LightAssertManager<TExpectedValue> Act(Action actAction)
        {
            actAction();
            var manager = new LightAssertManager<TExpectedValue>(ExpectedValue);
            return manager;
        }

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TActResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public AssertManager<TExpectedValue, TActResult> Act<TActResult>(Func<TActResult> actFunc)
        {
            var actResult = actFunc();
            var manager = new AssertManager<TExpectedValue, TActResult>(ExpectedValue, actResult);
            return manager;
        }
    }
}
