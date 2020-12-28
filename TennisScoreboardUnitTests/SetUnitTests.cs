using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TennisScoreboardBackend;

namespace TennisScoreboardUnitTests
{
    [TestClass]
    public class SetUnitTests
    {
        private Player firstPlayer = new Player("eli");
        private Player secondPlayer = new Player("yael");
        private bool win;
        [TestMethod]
        public void AddScoreLinearTest()
        {
            Set set = new Set(firstPlayer, secondPlayer);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    set.AddScore(firstPlayer, out win);
                }
                Assert.AreEqual((i +1).ToString(), set.AddScore(firstPlayer, out win));
            }
            Assert.IsTrue(win);
        }
        [TestMethod]
        public void AddScoreEdgeCase()
        {
            Set set = new Set(firstPlayer, secondPlayer);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    set.AddScore(firstPlayer, out win);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    set.AddScore(secondPlayer, out win);
                }
                Assert.AreEqual((i + 1).ToString(), set.AddScore(secondPlayer, out win));
            }
            Assert.IsTrue(win);
        }

        [TestMethod]
        public void resetScore()
        {
            Set set = new Set(firstPlayer, secondPlayer);
            for (int i = 0; i < 10; i++)
            {
                set.AddScore(firstPlayer, out win);
            }
            for (int i = 0; i < 10; i++)
            {
                set.AddScore(secondPlayer, out win);
            }
            set.ResetScore();
            Assert.AreEqual("0", set.AddScore(firstPlayer, out win), false, "Reset score did not return zero");
            Assert.AreEqual("0", set.AddScore(secondPlayer, out win), false, "Reset score did not return zero");
        }
        [TestMethod]
        public void GetScoreUnitTests()
        {
            Set set = new Set(firstPlayer, secondPlayer);
            List<string> expected = new List<string>{"0", "0" };
            CollectionAssert.AreEqual(expected, set.getScore()[firstPlayer.id]);
            expected[0] = "15";
            set.AddScore(firstPlayer, out win);
            CollectionAssert.AreEqual(expected, set.getScore()[firstPlayer.id]);
            expected[0] = "30";
            set.AddScore(firstPlayer, out win);
            CollectionAssert.AreEqual(expected, set.getScore()[firstPlayer.id]);
            expected[0] = "40";
            set.AddScore(firstPlayer, out win);
            CollectionAssert.AreEqual(expected, set.getScore()[firstPlayer.id]);
            expected[0] = "0";
            expected[1] = "1";
            set.AddScore(firstPlayer, out win);
            CollectionAssert.AreEqual(expected, set.getScore()[firstPlayer.id]);
        }
    }
}
