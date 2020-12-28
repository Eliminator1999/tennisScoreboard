using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisScoreboardBackend
{
    /// <summary>
    /// Class Game manages score of each player in a game (15, 30 ,40 ....)
    /// </summary>
    public class Game
    {
        private string[] possibleScore = { "0", "15", "30", "40", "win", "deuce", "advantage", "disadvantage" };
        private Dictionary<uint, string> pointScore { get; set; }
        public Game(Player firstPlayer, Player secondPlayer)
        {
            this.pointScore = new Dictionary<uint, string>
            {
                { firstPlayer.id, possibleScore[0] },
                { secondPlayer.id, possibleScore[0] }
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
            foreach (uint playerId in this.pointScore.Keys)
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
        /// <returns>A string representing the new score of the player</returns>
        public string AddScore(Player player)
        {
            uint otherPlayerId = getOtherPlayerId(player);
            switch (this.pointScore[player.id])
            {
                case "30":
                    if (this.pointScore[otherPlayerId] == "40")
                    {
                        this.pointScore[player.id] = "deuce";
                        this.pointScore[otherPlayerId] = "deuce";

                    }
                    else {
                        this.pointScore[player.id] = possibleScore[Array.IndexOf(possibleScore, pointScore[player.id]) + 1];
                    }
                    break;
                case "deuce":
                    this.pointScore[player.id] = "advantage";
                    this.pointScore[otherPlayerId] = "disadvantage";
                    break;
                case "disadvantage":
                    this.pointScore[player.id] = "deuce";
                    this.pointScore[otherPlayerId] = "deuce";
                    break;
                case "advantage":
                    this.pointScore[player.id] = "win";
                    break;
                default:
                    this.pointScore[player.id] = possibleScore[Array.IndexOf(possibleScore, pointScore[player.id]) + 1];
                    break;
            }
            return this.pointScore[player.id];
        }

        /// <summary>
        /// Reset the score of the game back to "0"
        /// </summary>
        public void ResetScore()
        {
            foreach (uint playerId in this.pointScore.Keys.ToList())
            {
                this.pointScore[playerId] = "0";
            }
        }

        ///<summary>return the game score of both players</summary>
        public Dictionary<uint, string> getScore()
        {
            return this.pointScore;
        }
    }
}
