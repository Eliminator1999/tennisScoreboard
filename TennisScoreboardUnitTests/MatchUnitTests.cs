using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisScoreboardBackend;

namespace TennisScoreboardUnitTests
{
    [TestClass]
    public class MatchUnitTests
    {
        private Player firstPlayer = new Player("eli");
        private Player secondPlayer = new Player("yael");
        [TestMethod]
        public void AddScoreLinearTest()
        {
            Match match = new Match(firstPlayer, secondPlayer);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    match.AddScore(firstPlayer);
                }
            }
            Assert.AreEqual((uint) 1, match.AddScore(firstPlayer));
        }
    }
}
