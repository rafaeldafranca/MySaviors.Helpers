using MySaviors.Helpers.Stuffs;
using Xunit;

namespace MySaviors.Helpers.Test.Stuffs
{
    public class CodeGeneratorTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(99)]
        [InlineData(100)]
        public void CodeGenerator_ValidStringValue(int size)
        {
            //Arrange


            // Act
            var code = CodeGenerator.Generate(size);

            // Assert
            Assert.NotNull(code);
            Assert.NotEqual(code, string.Empty);
            Assert.Equal(code.Length, size);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CodeGenerator_InvalidStringValue(int size)
        {
            //Arrange


            // Act
            var code = CodeGenerator.Generate(size);

            // Assert
            Assert.True(string.IsNullOrEmpty(code));
        }
    }
}
