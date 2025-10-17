using Logic.Helpers;
using System.Text;

namespace Logic
{
    public class Race(int RaceDistanceInMeters)
    {
        public List<Runner> Runners { get; init; } = [];

        public void AddRunner(string name, int minutesPerKm, int secondsPerKm) =>
            AddRunner(name, new TimeSpan(0, minutesPerKm, secondsPerKm));

        public void AddRunner(string name, TimeSpan timePerKm) =>
            AddRunner(name, (int)timePerKm.TotalSeconds);

        public void AddRunner(string name, int totalSecondsPerKm)
        {
            var runner = new Runner(name, totalSecondsPerKm, RaceDistanceInMeters);
            AddRunner(runner);
        }

        public void AddRunner(Runner runner) =>
            Runners.Add(runner);

        public string GetHcpTable()
        {
            var hcpTable = new StringBuilder();

            var runners = Runners.OrderByDescending(r => r.EstimatedSecondsForRace);
            var baseTimeInSeconds = runners.First().EstimatedSecondsForRace;

            foreach (var runner in runners)
            {
                var extraStartTimeInSeconds = baseTimeInSeconds - runner.EstimatedSecondsForRace;
                var startTime = TimeHelper.TextFromTime(extraStartTimeInSeconds);
                hcpTable.AppendLine($"{startTime} - {runner.Name}");
            }

            return hcpTable.ToString();
        }
    }
}
