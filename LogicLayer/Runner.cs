using Logic.Helpers;

namespace Logic
{
    public class Runner(
        string name,
        TimeSpan timePerKm,
        int raceDistanceInMeters)
    {
        public string Name =>
            name;

        public TimeSpan TimePerKm =>
            timePerKm;

        public TimeSpan TimePerMeter =>
            TimePerKm / 1000;

        public TimeSpan EstimatedTimeForRace =>
            TimePerMeter * raceDistanceInMeters;

        public string EstimatedTimeForRaceAsText =>
            TimeHelper.TextFromTime(EstimatedTimeForRace);
    }
}
