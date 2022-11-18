using MySaviors.Helpers.Types;
using Xunit;

namespace MySaviors.Helpers.Test.Types
{
    public class TimeTests
    {
        [Fact]
        public void Time_When_PassingValidHoursAndMinutesAndSecondsFromDateTimeNowValues_Should_Be_Success()
        {
            //Arrange
            var now = DateTime.Now;

            // Act
            Time time = string.Concat(now.Hour.ToString("0#"), ":", now.Minute.ToString("0#"), ":", now.Second.ToString("0#"));

            // Assert
            Assert.Equal(time.Hour, now.Hour);
            Assert.Equal(time.Minute, now.Minute);
            Assert.Equal(time.Second, now.Second);
            Assert.Equal(0, time.Millisecond);
        }

        [Fact]
        public void Time_When_PassingValidHoursAndMinutesAndSecondsFromDateTimeUtcNowValues_Should_Be_Success()
        {
            //Arrange
            var now = DateTime.UtcNow;

            // Act
            Time time = string.Concat(now.Hour.ToString("0#"), ":", now.Minute.ToString("0#"), ":", now.Second.ToString("0#"));

            // Assert
            Assert.Equal(time.Hour, now.Hour);
            Assert.Equal(time.Minute, now.Minute);
            Assert.Equal(time.Second, now.Second);
            Assert.Equal(0, time.Millisecond);
        }

        [Theory]
        [InlineData("12", "15", "27")]
        public void Time_When_PassingValidHoursAndMinutesAndSecondsValues_Should_Be_Success(string hours, string minutes, string seconds)
        {
            //Arrange


            // Act
            Time time = string.Concat(hours, ":", minutes, ":", seconds);

            // Assert
            Assert.Equal(time.Hour, Convert.ToInt32(hours));
            Assert.Equal(time.Minute, Convert.ToInt32(minutes));
            Assert.Equal(time.Second, Convert.ToInt32(seconds));
            Assert.Equal(0, time.Millisecond);
        }

        [Theory]
        [InlineData("12", "15", "27", "123")]
        public void Time_When_PassingValidHoursAndMinutesAndSecondsAndMillisecondsValues_Should_Be_Success(string hours, string minutes, string seconds, string milliseconds)
        {
            //Arrange


            // Act
            Time time = string.Concat(hours, ":", minutes, ":", seconds, ".", milliseconds);

            // Assert
            Assert.Equal(time.Hour, Convert.ToInt32(hours));
            Assert.Equal(time.Minute, Convert.ToInt32(minutes));
            Assert.Equal(time.Second, Convert.ToInt32(seconds));
            Assert.Equal(time.Millisecond, Convert.ToInt32(milliseconds));
        }

        [Fact]
        public void ToDateTime_When_PassingValidHoursAndMinutesAndSecondsAndMillisecondsValues_Should_Be_Success()
        {
            //Arrange
            var now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

            // Act
            Time time = (now.Hour, now.Minute, now.Second, now.Millisecond);

            // Assert
            Assert.Equal(time.ToDateTime(), now);
        }

        [Fact]
        public void ToDateTime_When_PassingValidHoursAndMinutesAndSecondsValues_Should_Be_Success()
        {
            //Arrange
            var now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0);

            // Act
            Time time = (now.Hour, now.Minute, now.Second);

            // Assert
            Assert.Equal(time.ToDateTime(), now);
        }

        [Fact]
        public void ToDateTime_When_PassingValidHoursAndMinutesValues_Should_Be_Success()
        {
            //Arrange
            var now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, 0, 0);

            // Act
            Time time = (now.Hour, now.Minute);

            // Assert
            Assert.Equal(time.ToDateTime(), now);
        }

        [Fact]
        public void ToDateTime_When_PassingValidHoursValue_Should_Be_Success()
        {
            //Arrange
            var now = new DateTime(1, 1, 1, DateTime.Now.Hour, 0, 0, 0);

            // Act
            Time time = now.Hour;

            // Assert
            Assert.Equal(time.ToDateTime(), now);
        }

    }
}

