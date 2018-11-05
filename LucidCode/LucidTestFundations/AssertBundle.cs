﻿using System;

namespace LucidCode.LucidTestFundations
{
    /// <summary>
    /// Bundle for Assert action
    /// </summary>
    /// <typeparam name="TExpectedValue">Type of expected value</typeparam>
    /// <typeparam name="TResult">Type of Act result</typeparam>
    public class AssertBundle<TExpectedValue, TResult> : ExpectedValueCarrier<TExpectedValue>
    {
        /// <summary>
        /// Act result
        /// </summary>
        public TResult ActResult { get; }

        /// <summary>
        /// AssertBundle constructor
        /// </summary>
        /// <param name="expectedValue"></param>
        /// <param name="result"></param>
        public AssertBundle(TExpectedValue expectedValue, TResult result)
            : base(expectedValue) => ActResult = result;

        /// <summary>
        /// Gets Act result and execute Assert actions
        /// </summary>
        /// <param name="assertAction">Assert action</param>
        public void Assert(Action<TResult, TExpectedValue> assertAction) => assertAction(ActResult, ExpectedValue);
    }
}