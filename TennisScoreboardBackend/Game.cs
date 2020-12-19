using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisScoreboardBackend
{
    public class Game
    {
        private string[] possibleScore = { "0", "15", "30", "40", "win", "deuce", "advantage", "disadvantage" };
        private IDictionary<uint, string> gameScore { get; set; }
        public Game(Player firstPlayer, Player secondPlayer)
        {
            this.gameScore = new Dictionary<uint, string>
            {
                { firstPlayer.id, possibleScore[0] },
                { secondPlayer.id, possibleScore[0] }
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
            uint otherPlayerId = getOtherPlayerId(player);
            switch (this.gameScore[player.id])
            {
                case "30":
                    if (this.gameScore[otherPlayerId] == "40")
                    {
                        this.gameScore[player.id] = "deuce";
                        this.gameScore[otherPlayerId] = "deuce";

                    }
                    else {
                        this.gameScore[player.id] = possibleScore[Array.IndexOf(possibleScore, gameScore[player.id]) + 1];
                    }
                    break;
                case "deuce":
                    this.gameScore[player.id] = "advantage";
                    this.gameScore[otherPlayerId] = "disadvantage";
                    break;
                case "disadvantage":
                    this.gameScore[player.id] = "deuce";
                    this.gameScore[otherPlayerId] = "deuce";
                    break;
                case "advantage":
                    this.gameScore[player.id] = "win";
                    break;
                default:
                    this.gameScore[player.id] = possibleScore[Array.IndexOf(possibleScore, gameScore[player.id]) + 1];
                    break;
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
