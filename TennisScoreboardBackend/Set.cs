using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisScoreboardBackend
{
    /// <summary>
    /// Class Set manages the amount of games won by each player (1-6/7)
    /// </summary>
    public class Set
    {
        private Game game;
        private Dictionary<uint, string> gameScore { get; set; }
        public Set(Player firstPlayer, Player secondPlayer)
        {
            game = new Game(firstPlayer, secondPlayer);
            this.gameScore = new Dictionary<uint, string>
            {
                { firstPlayer.id, "0"},
                { secondPlayer.id, "0"}
            };
        }

        /// <summary>
        /// Return the other player id.
        /// </summary>
        /// <param name="player">the known player</param>
        /// <returns>A uint representing the unknown player id</returns>
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

        /// <summary>
        /// Add score to a player
        /// </summary>
        /// <param name="player">the player who will get a point</param>
        /// <param name="win">a boolean determining if the player won a set (won 6 or 7 games)</param>
        /// <returns>A string representing the new score of the player</returns>
        public string AddScore(Player player, out bool win)
        {
            win = false;
            string pointScore = this.game.AddScore(player);
            if (pointScore == "win")
            {
                this.game.ResetScore();
                int newScore = Int16.Parse(this.gameScore[player.id]) + 1;
                int otherPlayerScore = Int16.Parse(this.gameScore[getOtherPlayerId(player)]);
                this.gameScore[player.id] = newScore.ToString();
                if (newScore == 7 || (newScore == 6 && otherPlayerScore < 5))
                {
                    win = true;
                }
                return this.gameScore[player.id];
                
            }
            
            return this.gameScore[player.id];
        }

        /// <summary>
        /// Reset the score of the set back to "0"
        /// </summary>
        public void ResetScore()
        {
            foreach (uint playerId in this.gameScore.Keys.ToList())
            {
                this.gameScore[playerId] = "0";
            }
        }

        ///<summary>return the set score of both players</summary>
        public Dictionary<uint, List<string>> getScore()
        {
            Dictionary<uint, List<string>> totalScore = new Dictionary<uint, List<string>>();
            Dictionary<uint, string> pointScore = game.getScore();
            foreach (uint playerID in pointScore.Keys)
            {
                List<string> score = new List<string> { pointScore[playerID], gameScore[playerID] };
                totalScore.Add(playerID, score);
            }
            return totalScore;
        }
    }
}
