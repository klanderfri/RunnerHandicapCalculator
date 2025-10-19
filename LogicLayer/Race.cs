using Logic.Helpers;
using System.Text;

namespace Logic
{
    public class Race(int RaceDistanceInMeters)
    {
        public List<Runner> Runners { get; init; } = [];

        public void AddRunner(string name, int minutesPerKm, int secondsPerKm) =>
            AddRunner(name, new TimeSpan(0, minutesPerKm, secondsPerKm));

        public void AddRunner(string name, int secondsPerKm) =>
            AddRunner(name, new TimeSpan(0, 0, secondsPerKm));

        public void AddRunner(string name, TimeSpan timePerKm) =>
            AddRunner(new Runner(name, timePerKm, RaceDistanceInMeters));

        public void AddRunner(Runner runner) =>
            Runners.Add(runner);

        private TimeSpan GetBaseTime() =>
            Runners
            .OrderByDescending(r => r.EstimatedTimeForRace)
            .First()
            .EstimatedTimeForRace;
        

        public string GetHcpTable()
        {
            var hcpTable = new StringBuilder();

            var runners = Runners.OrderByDescending(r => r.EstimatedTimeForRace);
            var baseTime = GetBaseTime();

            foreach (var runner in runners)
            {
                var extraStartTime = baseTime - runner.EstimatedTimeForRace;
                var startTime = TimeHelper.TextFromTime(extraStartTime);
                hcpTable.AppendLine($"{startTime} - {runner.Name}");
            }

            return hcpTable.ToString();
        }
    }
}
