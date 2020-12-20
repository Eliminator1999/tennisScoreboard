using System;
using System.Collections.Generic;
using System.Text;

namespace TennisScoreboardBackend
{
    public class Match
    {
        private Set set;
        private IDictionary<uint, uint> setScore { get; set; }
        public Match(Player firstPlayer, Player secondPlayer)
        {
            this.set = new Set(firstPlayer, secondPlayer);
            this.setScore = new Dictionary<uint, uint>
            {
                { firstPlayer.id, 0},
                { secondPlayer.id, 0}
            };
        }
        public uint AddScore(Player player)
        {
            string pointScore = this.set.AddScore(player);
            if (pointScore == "win")
            {
                setScore[player.id]++;
            }
            return setScore[player.id];
        }
    }
}
