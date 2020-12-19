using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoreboardBackend
{
    public class Set
    {
        private Game game;
        private IDictionary<uint, string> gameScore { get; set; }
        public Set(Player firstPlayer, Player secondPlayer)
        {
            game = new Game(firstPlayer, secondPlayer);
            this.gameScore = new Dictionary<uint, string>
            {
                { firstPlayer.id, "0"},
                { secondPlayer.id, "0"}
            };
        }
        private uint getOtherPlayerId(Player player)
        {
            uint otherPlayerId = 0;
            foreach (uint playerId in this.gameScore.Keys)
            {
                if (playerId != player.id)
                {
                    otherPlayerId = playerId;
                }
            }
            return otherPlayerId;
        }

        public string AddScore(Player player)
        {
            string pointScore = this.game.AddScore(player);
            if (pointScore == "win")
            {
                this.game.ResetScore();
                int newScore = Int16.Parse(this.gameScore[player.id]) + 1;
                int otherPlayerScore = Int16.Parse(this.gameScore[getOtherPlayerId(player)]);
                this.gameScore[player.id] = newScore.ToString();
                if (newScore == 7 || (newScore == 6 && otherPlayerScore < 5))
                {
                    return "win";
                }
                else
                {
                    return this.gameScore[player.id];
                }
                
            }
            
            return this.gameScore[player.id];
        }
        public void ResetScore()
        {
            foreach (uint playerId in this.gameScore.Keys.ToList())
            {
                this.gameScore[playerId] = "0";
            }
        }
    }
}
