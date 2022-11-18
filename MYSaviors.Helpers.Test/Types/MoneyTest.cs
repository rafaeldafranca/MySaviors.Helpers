﻿using MySaviors.Helpers.Types;
using Xunit;

namespace MySaviors.Helpers.Test.Types
{
    public class MoneyTest
    {
        [Theory]
        [InlineData("10.00", 10)]
        [InlineData("10,000.00", 10000)]
        public void ValidMoney_StringValue(string value, decimal finalValue)
        {
            //Arrange
            Money money = value;

            // Act

            // Assert
            Assert.True(money.IsValid());
            Assert.True(Money.IsValid(value));
            Assert.Equal(money.Value, finalValue);
        }

        [Theory]
        [InlineData(10.00)]
        public void ValidMoney_LongValue(decimal value)
        {
            //Arrange
            Money money = value;

            // Act

            // Assert
            Assert.True(money.IsValid());
            Assert.Equal(money.Value, value);
        }

        [Theory]
        [InlineData(".0")]
        [InlineData("10.")]
        [InlineData("10.0")]
        [InlineData(",0")]
        [InlineData("10,")]
        [InlineData("10,0")]
        [InlineData("10,000")]
        [InlineData("10")]
        [InlineData("10.000,00")]
        [InlineData("10.000,000")]
        public void InvalidMoney_StringValue(string value)
        {
            //Arrange
            Money money = value;

            // Act

            // Assert
            Assert.False(money.IsValid());
            Assert.False(Money.IsValid(value));
        }
    }
}
