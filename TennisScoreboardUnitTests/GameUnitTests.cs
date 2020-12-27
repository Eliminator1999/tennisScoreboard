using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisScoreboardBackend;

namespace TennisScoreboardUnitTests
{
    [TestClass]
    public class GameUnitTests
    {
        private Player firstPlayer = new Player("eli");
        private Player secondPlayer = new Player("yael");

        [TestMethod]
        public void AddScoreLinearTest()
        {
            Game game = new Game(firstPlayer, secondPlayer);
            Assert.AreEqual("15", game.AddScore(firstPlayer), false, "Score was not calculated correctly");
            Assert.AreEqual("30", game.AddScore(firstPlayer), false, "Score was not calculated correctly");
            Assert.AreEqual("40", game.AddScore(firstPlayer), false, "Score was not calculated correctly");
            Assert.AreEqual("win", game.AddScore(firstPlayer), false, "Score was not calculated correctly");

        }
        [TestMethod]
        public void AddScoreDeuceAdvantageTest()
        {
            Game game = new Game(firstPlayer, secondPlayer);
            for (int i = 0; i < 3; i++)
            {
                game.AddScore(firstPlayer);
                game.AddScore(secondPlayer);
            }
            Assert.AreEqual("advantage", game.AddScore(firstPlayer), false, "Score was not calculated correctly");
            Assert.AreEqual("deuce", game.AddScore(secondPlayer), false, "Score was not calculated correctly");
            Assert.AreEqual("advantage", game.AddScore(secondPlayer), false, "Score was not calculated correctly");
            Assert.AreEqual("win", game.AddScore(secondPlayer), false, "Score was not calculated correctly");

        }
        [TestMethod]
        public void ResetScoreUnitTest()
        {
            Game game = new Game(firstPlayer, secondPlayer);
            game.AddScore(firstPlayer);
            game.AddScore(secondPlayer);
            game.ResetScore();
            Assert.AreEqual("15", game.AddScore(firstPlayer), false, "Reset score did not return zero");
            Assert.AreEqual("15", game.AddScore(secondPlayer), false, "Reset score did not return zero");
        }
        [TestMethod]
        public void GetScoreUnitTests() 
        {
            Game game = new Game(firstPlayer, secondPlayer);
            Assert.AreEqual("0", game.getScore()[firstPlayer.id], false, "GetScore exited with an error");
            game.AddScore(firstPlayer);
            Assert.AreEqual("15", game.getScore()[firstPlayer.id], false, "GetScore exited with an error");
            game.AddScore(firstPlayer);
            Assert.AreEqual("30", game.getScore()[firstPlayer.id], false, "GetScore exited with an error");
            game.AddScore(firstPlayer);
            Assert.AreEqual("40", game.getScore()[firstPlayer.id], false, "GetScore exited with an error");
            game.AddScore(firstPlayer);
            Assert.AreEqual("win", game.getScore()[firstPlayer.id], false, "GetScore exited with an error");
        }
    }
}
