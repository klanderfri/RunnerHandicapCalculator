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

        public string GetRunnersCsvData()
        {
            var csv = new StringBuilder();
            csv.AppendLine("Name,Tempo (sec/km),Start time (sec),Estimated finish time (sec)");

            var baseTime = GetBaseTime();
            var runners = Runners.OrderBy(r => r.Name);
            foreach (var runner in runners)
            {
                var tempo = Math.Round(runner.TimePerKm.TotalSeconds);
                var startSeconds = Math.Round((baseTime - runner.EstimatedTimeForRace).TotalSeconds);
                var finishSeconds = Math.Round(runner.EstimatedTimeForRace.TotalSeconds);

                csv.AppendLine($"{runner.Name},{tempo},{startSeconds},{finishSeconds}");
            }

            return csv.ToString();
        }
    }
}
