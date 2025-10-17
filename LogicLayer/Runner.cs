using Logic.Helpers;

namespace Logic
{
    public class Runner(
        string name,
        int secondsPerKm,
        int raceDistanceInMeters)
    {
        public string Name =>
            name;

        public int SecondsPerKm =>
            secondsPerKm;

        public double SecondsPerMeter =>
            SecondsPerKm / (double)1000;

        public int EstimatedSecondsForRace =>
            (int)Math.Round(raceDistanceInMeters * SecondsPerMeter);

        public string EstimatedTimeForRace =>
            TimeHelper.TextFromTime(EstimatedSecondsForRace);
    }
}
