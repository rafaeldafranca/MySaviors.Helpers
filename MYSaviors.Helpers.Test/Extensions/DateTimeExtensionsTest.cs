using MySaviors.Helpers.Extensions;
using Xunit;

namespace MySaviors.Helpers.Test.Extensions
{
    public class DateTimeExtensionsTest
    {
        [Theory]
        [InlineData("2020-12-18 00:00:00", "2020-12-01 00:00:00")]
        [InlineData("2020-02-25 00:00:00", "2020-02-01 00:00:00")]
        public void DateTimeExtensions_FirstDayOfMonth_When_PassingValidStringValidDate_Should_FirstDayOfMonth(string value, DateTime refDate)
        {
            // Arrange


            // Act
            var date = value.FirstDayOfMonth();


            // Assert
            Assert.Equal(date.Value.Date, refDate.Date);
        }

        [Theory]
        [InlineData("2020-12-18 00:00:00", "2020-12-01 00:00:00")]
        [InlineData("2020-02-25 00:00:00", "2020-02-01 00:00:00")]
        public void DateTimeExtensions_FirstDayOfMonth_When_PassingValidDateTimeValidDate_Should_FirstDayOfMonth(DateTime value, DateTime refDate)
        {
            // Arrange


            // Act
            var date = value.FirstDayOfMonth();


            // Assert
            Assert.Equal(date.Date, refDate.Date);
        }

        [Theory]
        [InlineData("2020-12-18 00:00:00", "2020-12-31 00:00:00")]
        [InlineData("2020-02-25 00:00:00", "2020-02-29 00:00:00")]
        [InlineData("2018-02-15 00:00:00", "2018-02-28 00:00:00")]
        public void DateTimeExtensions_LastDayOfMonth_When_PassingValidStringValidDate_Should_LastDayOfMonth(string value, DateTime refDate)
        {
            // Arrange


            // Act
            var date = value.LastDayOfMonth();


            // Assert
            Assert.Equal(date.Value, refDate.Date);
        }

        [Theory]
        [InlineData("2020-12-18 00:00:00", "2020-12-31 00:00:00")]
        [InlineData("2020-02-25 00:00:00", "2020-02-29 00:00:00")]
        [InlineData("2018-02-15 00:00:00", "2018-02-28 00:00:00")]
        public void DateTimeExtensions_LastDayOfMonth_When_PassingValidDateTimeValidDate_Should_LastDayOfMonth(DateTime value, DateTime refDate)
        {
            // Arrange


            // Act
            var date = value.LastDayOfMonth();


            // Assert
            Assert.Equal(date.Date, refDate.Date);
        }

        [Theory]
        [InlineData("2020-12-18 00:00:00", "2021-12-18 00:00:00", 1)]
        [InlineData("2020-12-18 00:00:00", "2022-12-18 00:00:00", 2)]
        [InlineData("2021-12-18 00:00:00", "2021-12-18 00:00:00", 0)]
        [InlineData("2021-12-18 00:00:00", "2020-12-18 00:00:00", 1)]
        public void DateTimeExtensions_DiffInYears_When_PassingValidTwoDateTime_Should_DiffInYears(DateTime value, DateTime compareDate, int diff)
        {
            // Arrange


            // Act
            var diffInYears = value.DiffInYears(compareDate);


            // Assert
            Assert.Equal(diffInYears, diff);
        }

        [Theory]
        [InlineData("2018-12-18 02:12:23.123")]
        [InlineData("2019-12-18 02:12:23.123")]
        [InlineData("2020-12-18 02:12:23.123")]
        [InlineData("2021-12-18 02:12:23.123")]
        public void DateTimeDeconstructor_When_PassingValidDateTime_Should_TupleWithDateTimeValues(DateTime value)
        {
            // Arrange


            // Act
            var tuple = value.DateTimeDeconstructor();


            // Assert
            Assert.Equal(tuple.Year, value.Year);
            Assert.Equal(tuple.Month, value.Month);
            Assert.Equal(tuple.Day, value.Day);
            Assert.Equal(tuple.Hours, value.Hour);
            Assert.Equal(tuple.Minutes, value.Minute);
            Assert.Equal(tuple.Seconds, value.Second);
            Assert.Equal(tuple.Milliseconds, value.Millisecond);
        }

        [Theory]
        [InlineData("2018-12-18 02:12:23.123")]
        [InlineData("2019-12-18 02:12:23.123")]
        [InlineData("2020-12-18 02:12:23.123")]
        [InlineData("2021-12-18 02:12:23.123")]
        public void TimeDeconstructor_When_PassingValidDateTime_Should_TupleWithDateTimeValues(DateTime value)
        {
            // Arrange


            // Act
            var tuple = value.TimeDeconstructor();


            // Assert
            Assert.Equal(tuple.Hours, value.Hour);
            Assert.Equal(tuple.Minutes, value.Minute);
            Assert.Equal(tuple.Seconds, value.Second);
            Assert.Equal(tuple.Milliseconds, value.Millisecond);
        }


        [Theory]
        [InlineData("2018-12-18", "2018-12-19", 1)]
        [InlineData("2018-12-18", "2018-12-20", 2)]
        [InlineData("2018-12-18", "2018-12-21", 3)]
        [InlineData("2018-12-18", "2018-12-24", 4)]
        [InlineData("2018-12-18", "2018-12-25", 5)]
        [InlineData("2018-12-18", "2018-12-26", 6)]
        [InlineData("2018-12-18", "2018-12-27", 7)]
        [InlineData("2018-12-18", "2018-12-28", 8)]
        [InlineData("2018-12-18", "2018-12-31", 9)]
        [InlineData("2018-12-18", "2019-01-01", 10)]
        [InlineData("2018-12-18", "2019-01-02", 11)]
        [InlineData("2018-12-18", "2019-01-03", 12)]
        [InlineData("2018-12-18", "2019-01-04", 13)]
        [InlineData("2018-12-18", "2019-01-07", 14)]
        [InlineData("2018-12-18", "2019-01-08", 15)]
        [InlineData("2018-12-18", "2019-01-09", 16)]
        [InlineData("2018-12-18", "2019-01-10", 17)]
        [InlineData("2018-12-18", "2018-12-18", -1)]
        [InlineData("2018-12-18", "2018-12-18", -12)]
        public void AddWorkingDays_When_PassingValidDateTime_Should_Be_(DateTime baseDate, DateTime finalValue, double daysToAdd)
        {
            // Arrange


            // Act
            var response = baseDate.AddWorkingDays(daysToAdd);

            // Assert
            Assert.Equal(response.Subtract(finalValue), TimeSpan.Zero);
        }
    }
}
