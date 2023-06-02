using MySaviors.Helpers.Extensions;
using Xunit;

namespace MySaviors.Helpers.Test.Extensions
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("2020", 2, "20")]
        [InlineData("20", 2, "20")]
        [InlineData("2", 2, "")]
        [InlineData("", 2, "")]
        [InlineData("2020", -1, "")]
        public void TakeString_ReturnAllFounded_False_StringValue(string value, int tamanho, string resultado)
        {
            var result = value.TakeString(tamanho);

            Assert.Equal(result, resultado);
        }

        [Theory]
        [InlineData("2020", 2, "20")]
        [InlineData("20", 2, "20")]
        [InlineData("2", 2, "2")]
        [InlineData("", 2, "")]
        [InlineData("2020", -1, "")]
        public void TakeString_ReturnAllFounded_True_StringValue(string value, int tamanho, string resultado)
        {
            var result = value.TakeString(tamanho, true);

            Assert.Equal(result, resultado);
        }

        [Theory]
        [InlineData("2020", 1, 2, "02")]
        [InlineData("2020", 2, 2, "20")]
        [InlineData("2020", 3, 2, "")]
        [InlineData("2020", 4, 2, "")]
        [InlineData("20", 1, 2, "")]
        [InlineData("2", 1, 2, "")]
        [InlineData("", 1, 2, "")]
        [InlineData("2020", 1, -1, "")]
        public void TakeString_ReturnAllFounded_False_IniPosition_StringValue(string value, int iniPosition, int tamanho, string resultado)
        {
            var result = value.TakeString(iniPosition, tamanho);

            Assert.Equal(result, resultado);
        }

        [Theory]
        [InlineData("2020", 1, 2, "02")]
        [InlineData("2020", 2, 2, "20")]
        [InlineData("2020", 3, 2, "0")]
        [InlineData("2020", 4, 2, "")]
        [InlineData("20", 1, 2, "0")]
        [InlineData("2", 1, 2, "")]
        [InlineData("", 1, 2, "")]
        [InlineData("2020", 1, -1, "")]
        public void TakeString_ReturnAllFounded_True_IniPosition_StringValue(string value, int iniPosition, int tamanho, string resultado)
        {
            var result = value.TakeString(iniPosition, tamanho, true);

            Assert.Equal(result, resultado);
        }

        [Theory]
        [InlineData("100", 3)]
        [InlineData("156", 7)]
        public void FillRightZeros_ReturnZeros(string value, int tamanho)
        {
            var result = value.FillRightZeros(tamanho);
            string str = string.Concat(Enumerable.Repeat("0", tamanho));
            Assert.Equal(str, result.Substring(result.Count() - tamanho));
        }

        [Theory]
        [InlineData("email@email.com")]
        [InlineData("email@email.com.br")]
        [InlineData("email@email.aa")]
        public void IsEmail_ShouldBeTrue(string value)
        {
            var result = value.IsEmail();
            Assert.True(result);
        }

        [Theory]
        [InlineData("emailemail.com")]
        [InlineData("email@.com")]
        [InlineData("email@email")]
        [InlineData("@email.aa")]
        public void IsEmail_ShouldBeFalse(string value)
        {
            var result = value.IsEmail();
            Assert.False(result);
        }

        [Fact]
        public void FromSpaceSeparatedString_MustBe_Success()
        {
            var name = "Rafael França";
            var a = name.FromSpaceSeparatedString();

            Assert.Equal(2, a.Count());
        }

        [Theory]
        [InlineData("www.google.com/", "www.google.com")]
        [InlineData("www.google.com", "www.google.com")]
        public void CleanUrlPath_MustBe_Success(string value, string result)
        {
            var a = value.CleanUrlPath();

            Assert.Equal(a, result);
        }

        [Fact]
        public void QueyString_Full_Link_With_Querystring()
        {
            var url = "http://teste.com";
            var value = url.AddQueyString("param1", "1");
            value = value.AddQueyString("param2", "2");
            value = value.AddQueyString("param3", "3");
            Assert.Equal(value, $"{url}?param1=1&param2=2&param3=3");
        }
    }
}
