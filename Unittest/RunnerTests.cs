using Logic;

namespace Unittest
{
    public class RunnerTests
    {
        [Theory]
        [InlineData("Adam", 5, 31, 6040, "33:19")]
        //Checks for rounding error as total time = 27 minutes and 16,84 seconds.
        [InlineData("Bertil", 4, 31, 6040, "27:17")]
        public void CreateRunnerTest(
            string name,
            int minutesPerKm,
            int secondsPerKm,
            int raceDistance,
            string expectedRaceTime)
        {
            var timePerKm = new TimeSpan(0, minutesPerKm, secondsPerKm);
            var adam = new Runner(name, timePerKm, raceDistance);

            Assert.Equal(expectedRaceTime, adam.EstimatedTimeForRaceAsText);
        }
    }
}
