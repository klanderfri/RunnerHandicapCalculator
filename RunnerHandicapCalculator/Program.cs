using Logic;
using Logic.Helpers;

namespace RunnerHandicapCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many runners will race? ");
            var numberOfRunners = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("How many meters is the race? ");
            var raceDistanceInMeter = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            var race = new Race(raceDistanceInMeter);
            for (int i = 0; i < numberOfRunners; i++)
            {
                Console.WriteLine($"Enter name of runner #{i + 1}: ");
                var name = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine($"How fast does {name} run 1000 meters?");
                if (i == 0)
                {
                    Console.WriteLine("(Enter as <minutes>:<seconds>, e.g 5:31)");
                }
                var secondsPerKm = TimeHelper.TimeFromText(Console.ReadLine(), ':');
                Console.WriteLine();

                race.AddRunner(name, secondsPerKm);
            }

            Console.WriteLine("The HCP-adjusted start times are as follows:");
            Console.WriteLine(race.GetHcpTable());
        }
    }
}
