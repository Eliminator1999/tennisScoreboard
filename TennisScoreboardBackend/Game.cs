using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoreboardBackend
{
    public class Game
    {
        private string[] possibleScore = { "0", "15", "30", "40", "win", "deuce", "advantage", "disadvantage" };
        private IDictionary<uint, string> pointScore { get; set; }
        public Game(Player firstPlayer, Player secondPlayer)
        {
            this.pointScore = new Dictionary<uint, string>
            {
                { firstPlayer.id, possibleScore[0] },
                { secondPlayer.id, possibleScore[0] }
            };
        }

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

        public void ResetScore()
        {
            foreach (uint playerId in this.pointScore.Keys.ToList())
            {
                this.pointScore[playerId] = "0";
            }
        }
    }
}
