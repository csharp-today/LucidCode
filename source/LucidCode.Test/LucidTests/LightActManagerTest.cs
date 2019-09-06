﻿using LucidCode.LucidTestFundations;
using Shouldly;
using Xunit;

namespace LucidCode.Test.LucidTests
{
    public class LightActManagerTest
    {
        private const string ExpectedResult = "value";
        private const string ExpectedValue = "value";

        [Fact]
        public void LightActManager_Provides_AssertManager()
        {
            // Arrange
            bool actExecutedFine = false;

            // Act
            AssertManager<string> manager =
                new LightActManager()
                .Act(() =>
                {
                    actExecutedFine = true;
                    return ExpectedResult;
                });

            // Assert
            actExecutedFine.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ActResult.ShouldBe(ExpectedResult);
        }

        [Fact]
        public void LightActManager_Provides_LightAssertManager()
        {
            // Arrange
            bool actExecutedFine = false;

            // Act
            LightAssertManager manager =
                new LightActManager()
                .Act(() => { actExecutedFine = true; });

            // Assert
            manager.ShouldNotBeNull();
            actExecutedFine.ShouldBeTrue();
        }

        [Fact]
        public void LightActManager_With_ExpectedValue_Provides_AssertManager()
        {
            // Arrange
            bool actExecutedFine = false;

            // Act
            AssertManager<string, string> manager =
                new LightActManager<string>(ExpectedValue)
                .Act(() =>
                {
                    actExecutedFine = true;
                    return ExpectedResult;
                });

            // Assert
            actExecutedFine.ShouldBeTrue();
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
            manager.ActResult.ShouldBe(ExpectedResult);
        }

        [Fact]
        public void LightActManager_With_ExpectedValue_Provides_LightAssertManagetr()
        {
            // Arrange
            bool actExecutedFine = false;

            // Act
            LightAssertManager<string> manager =
                new LightActManager<string>(ExpectedValue)
                .Act(() => { actExecutedFine = true; });

            // Assert
            manager.ShouldNotBeNull();
            manager.ExpectedValue.ShouldBe(ExpectedValue);
            actExecutedFine.ShouldBeTrue();
        }
    }
}