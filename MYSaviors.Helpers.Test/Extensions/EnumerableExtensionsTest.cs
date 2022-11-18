using MySaviors.Helpers.Extensions;
using Xunit;

namespace MySaviors.Helpers.Test.Extensions
{
    public class EnumerableExtensionsTest
    {
        [Fact]
        public void SForEach_Sum()
        {
            var list = new List<ListTest>
            {
                new ListTest { Value = 1 },
                new ListTest { Value = 2 },
                new ListTest { Value = 3 }
            };

            list = list.SForEach(s => s.Value = s.Value + 1).ToList();

            Assert.Equal(9, list.Sum(v => v.Value));
        }

        [Fact]
        public void SForEach_Empty()
        {
            var list = new List<ListTest>();

            list = list.SForEach(s => s.Value = s.Value + 1).ToList();

            Assert.Equal(0, list.Sum(v => v.Value));
        }

        [Fact]
        public void SForEach_Null()
        {
            IEnumerable<ListTest> list = null;

            list = list.SForEach(s => s.Value = s.Value + 1);

            Assert.Null(list);
        }

        [Fact]
        public void SFirstOrDefault_NotNull()
        {
            var list = new List<ListTest>
            {
                new ListTest { Value = 1 },
                new ListTest { Value = 2 },
                new ListTest { Value = 3 }
            };

            var item = list.SFirstOrDefault();

            Assert.NotNull(item);
            Assert.Equal(1, item.Value);
        }

        [Fact]
        public void SFirstOrDefault_NotNull_WithPredicate()
        {
            var list = new List<ListTest>
            {
                new ListTest { Value = 1 },
                new ListTest { Value = 2 },
                new ListTest { Value = 3 }
            };

            var item = list.SFirstOrDefault(p => p.Value == 1);

            Assert.NotNull(item);
            Assert.Equal(1, item.Value);
        }

        [Fact]
        public void SFirstOrDefault_Null()
        {
            List<ListTest> list = null;

            var item = list.SFirstOrDefault();

            Assert.NotNull(item);
        }

        [Fact]
        public void SFirstOrDefault_Null_WithPredicate()
        {
            List<ListTest> list = null;

            var item = list.SFirstOrDefault(p => p.Value == 1);

            Assert.NotNull(item);
        }

        [Fact]
        public void AddIfNotNull_When_ListIsNotNullAndValueIsNotNull_Should_Be_SuccessAdded()
        {
            // Arrange
            var value = new ListTest { Value = 1 };

            // Act
            var list = new List<ListTest>().AddIfNotNull(value);

            // Assert
            Assert.Equal(list.Single().Value, value.Value);
        }

        [Fact]
        public void AddIfNotNull_When_ListIsNotNullAndValueIsNotNullAndCheckClauseIsFalse_Should_Be_DontAddedAndDontThrowException()
        {
            // Arrange
            var value = new ListTest { Value = 1 };

            // Act
            var list = new List<ListTest>().AddIfNotNull(value, () => value.Value > 1);

            // Assert
            Assert.Empty(list);
        }

        [Fact]
        public void AddIfNotNull_When_ListIsNotNullAndValueIsNotNullAndCheckClauseIsTrue_Should_Be_SuccessAdded()
        {
            // Arrange
            var value = new ListTest { Value = 1 };

            // Act
            var list = new List<ListTest>().AddIfNotNull(value, () => value.Value > 0);

            // Assert
            Assert.Equal(list.Single().Value, value.Value);
        }

        [Fact]
        public void AddIfNotNull_When_ListIsNullAndValueIsNotNull_Should_Be_DontThrowException()
        {
            // Arrange
            List<ListTest> list = null;
            var value = new ListTest { Value = 1 };

            // Act
            var result = list.AddIfNotNull(value);

            // Assert
            Assert.Null(list);
            Assert.Null(result);
        }

        [Fact]
        public void AddIfNotNull_When_ListIsNotNullAndValueIsNull_Should_Be_DontAddedAndDontThrowException()
        {
            // Arrange
            ListTest value = null;

            // Act
            var list = new List<ListTest>().AddIfNotNull(value);

            // Assert
            Assert.Empty(list);
        }

        [Fact]
        public void AddIfNotNull_When_ListIsNullAndValueIsNull_Should_Be_DontThrowException()
        {
            // Arrange
            List<ListTest> list = null;
            ListTest value = null;

            // Act
            var result = list.AddIfNotNull(value);

            // Assert
            Assert.Null(list);
            Assert.Null(result);
        }
    }

    public class ListTest
    {
        public int Value { get; set; }
    }
}
