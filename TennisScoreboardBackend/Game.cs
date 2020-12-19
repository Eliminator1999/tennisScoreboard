using System;
using System.Collections.Generic;
using System.Text;

namespace TennisScoreboardBackend
{
    public class Game
    {
        private IDictionary<uint, string> gameScore { get; set; }
        public Game(Player firstPlayer, Player secondPlayer)
        {
            this.gameScore = new Dictionary<uint, string>
            {
                { firstPlayer.id, "0" },
                { secondPlayer.id, "0" }
            };
        }

        public string AddScore(Player player)
        {
            return "";
        }

        public void ResetScore()
        {

        }
    }
}
