using MySaviors.Helpers.Types;
using Xunit;

namespace MySaviors.Helpers.Test.Types
{
    public class CepTest
    {
        [Theory]
        [InlineData("20.557-124")]
        [InlineData("20557124")]    
        public void ValidCep_StringValue(string value)
        {
            //Arrange
            Cep cep = value;

            // Act

            // Assert
            Assert.True(cep.IsValid());
        }

        [Theory]
        [InlineData("20.557-12")]
        [InlineData("2055712")]
        public void InvalidCep_StringValue(string value)
        {
            //Arrange
            Cep cep = value;

            // Act

            // Assert
            Assert.False(cep.IsValid());
        }

        [Theory]
        [InlineData(20557124)]
        public void ValidCep_LongValue(long value)
        {
            //Arrange
            Cep cep = value;

            // Act

            // Assert
            Assert.True(cep.IsValid());
        }

        [Theory]
        [InlineData(2055714)]
        public void InvalidCep_LongValue(long value)
        {
            //Arrange
            Cep cep = value;

            // Act

            // Assert
            Assert.False(cep.IsValid());
        }
    }
}