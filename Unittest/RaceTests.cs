using Logic;

namespace Unittest
{
    public class RaceTests
    {
        [Fact]
        public void CreateHcpTableTest()
        {
            var race = new Race(6040);
            race.AddRunner("Cesar", 4, 32);
            race.AddRunner("Erik", 4, 8);
            race.AddRunner("David", 4, 32);
            race.AddRunner("Adam", 5, 31);
            race.AddRunner("Bertil", 4, 45);

            var actualHcpTable = race.GetHcpTable();
            var expectedHcpTable = "0:00 - Adam\r\n4:38 - Bertil\r\n5:56 - Cesar\r\n5:56 - David\r\n8:21 - Erik\r\n";

            Assert.Equal(expectedHcpTable, actualHcpTable);
        }
    }
}
