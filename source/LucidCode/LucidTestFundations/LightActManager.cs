using System;
using System.Threading.Tasks;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Manager for Act step
    /// </summary>
    public class LightActManager
    {
        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public LightAssertManager Act(Action actAction)
        {
            actAction();
            var manager = new LightAssertManager();
            return manager;
        }

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public AssertManager<TResult> Act<TResult>(Func<TResult> actFunc)
        {
            var result = actFunc();
            var manager = new AssertManager<TResult>(result);
            return manager;
        }

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public async Task<LightAssertManager> ActAsync(Func<Task> actAction)
        {
            await actAction();
            return new LightAssertManager();
        }

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public async Task<AssertManager<TResult>> ActAsync<TResult>(Func<Task<TResult>> actFunc)
        {
            var result = await actFunc();
            return new AssertManager<TResult>(result);
        }
    }

    /// <summary>
    /// Manager for Act step
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value for Arrange and Assert steps</typeparam>
    public class LightActManager<TExpectedValue> : ExpectedValueManager<TExpectedValue>
    {
        internal LightActManager(TExpectedValue expectedValue) : base(expectedValue) { }

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
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public AssertManager<TExpectedValue, TResult> Act<TResult>(Func<TResult> actFunc)
        {
            var result = actFunc();
            var manager = new AssertManager<TExpectedValue, TResult>(ExpectedValue, result);
            return manager;
        }

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <param name="actAction">Act action</param>
        /// <returns>Manager for Assert step</returns>
        public async Task<LightAssertManager<TExpectedValue>> ActAsync(Func<Task> actAction)
        {
            await actAction();
            return new LightAssertManager<TExpectedValue>(ExpectedValue);
        }

        /// <summary>
        /// Execute Act step
        /// </summary>
        /// <typeparam name="TResult">Type of Act result. Use anonymous type for multiple values.</typeparam>
        /// <param name="actFunc">Act function</param>
        /// <returns>Manager for Assert step</returns>
        public async Task<AssertManager<TExpectedValue, TResult>> ActAsync<TResult>(Func<Task<TResult>> actFunc)
        {
            var result = await actFunc();
            return new AssertManager<TExpectedValue, TResult>(ExpectedValue, result);
        }
    }
}
