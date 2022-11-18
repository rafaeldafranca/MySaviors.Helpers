using MySaviors.Helpers.Extensions;
using System.ComponentModel;
using Xunit;

namespace MySaviors.Helpers.Test.Extensions
{
    public enum DataAnnotationEnumTest
    {
        [Description("Value #01")]
        Value01 = 1,
        [Description("Value #02")]
        Value02 = 2
    }

    [Description("Value #01")]
    public class DataAnnotationClassTest
    {
        [Description("Attribute #01")]
        public string Name { get; set; }
    }

    public class DataAnnotationsExtensionsTests
    {
        [Theory]
        [InlineData(DataAnnotationEnumTest.Value01, "Value #01")]
        [InlineData(DataAnnotationEnumTest.Value02, "Value #02")]
        public void DataAnnotationsExtensions_DescriptionFromEnum_When_GetDescription_Should_Success(DataAnnotationEnumTest value, string message)
        {
            // Arrange

            // Act
            var valueDescription = value.Description();

            // Assert
            Assert.Equal(valueDescription, message);
        }

        [Fact]
        public void DataAnnotationsExtensions_DescriptionFromType_When_GetTypeDescription_Should_Success()
        {
            // Arrange
            var type = typeof(DataAnnotationClassTest);

            // Act
            var valueDescription = type.Description();

            // Assert
            Assert.Equal("Value #01", valueDescription);
        }

        [Fact]
        public void DataAnnotationsExtensions_DescriptionFromType_When_GetAttributeDescription_Should_Success()
        {
            // Arrange
            var type = typeof(DataAnnotationClassTest);

            // Act
            var attributeValueDescription = type.AttributeDescription("Name");

            // Assert
            Assert.Equal("Attribute #01", attributeValueDescription);
        }
    }
}
