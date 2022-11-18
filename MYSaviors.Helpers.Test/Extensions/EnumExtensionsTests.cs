using MySaviors.Helpers.Extensions;
using System.ComponentModel;
using Xunit;

namespace MySaviors.Helpers.Test.Extensions
{
    public class EnumExtensionsTests
    {
        public enum TOperation
        {
            Undefined = 0,

            [Description("Transação")]
            Transacao = 1,
            [Description("Aprovação")]
            Aprovacao = 2,
        }

        [Theory]
        [InlineData(TOperation.Undefined)]
        [InlineData(TOperation.Transacao)]
        [InlineData(TOperation.Aprovacao)]
        public void ParseExact_When_PassingValidEnumItem_Should_Be_Success(TOperation operation)
        {
            //Arrange

            //Act
            TOperation res = operation.ParseExact(operation.GetHashCode().ToString());

            //Assert
            Assert.Equal(res, operation);
        }

        [Theory]
        [InlineData(TOperation.Undefined)]
        [InlineData(TOperation.Transacao)]
        [InlineData(TOperation.Aprovacao)]
        public void ParseExact_When_PassingValidEnumItemWithDefaultValue_Should_Be_Success(TOperation operation)
        {
            //Arrange

            //Act
            TOperation res = operation.ParseExact("99", operation);

            //Assert
            Assert.Equal(res, operation);
        }

        [Fact]
        public void ParseExact_When_PassingValidEnumItemWithoutDefaultValue_Should_Be_Success()
        {
            //Arrange
            TOperation operation = TOperation.Transacao;

            //Act
            TOperation res = operation.ParseExact("99");

            //Assert
            Assert.Equal(res, TOperation.Undefined);
        }

        [Fact]
        public void ToList_When_GetEnumElements_Should_Be_Success()
        {
            //Arrange
            TOperation operation = TOperation.Transacao;

            //Act
            var elements = operation.ToList();

            //Assert
            Assert.NotNull(elements);
            Assert.Equal(elements.Count, 3);
            Assert.Equal(elements[0], TOperation.Undefined);
            Assert.Equal(elements[1], TOperation.Transacao);
            Assert.Equal(elements[2], TOperation.Aprovacao);
        }
    }
}
