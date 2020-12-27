using System;
using System.Collections.Generic;
using System.Text;

namespace TennisScoreboardBackend
{
    public class Match
    {
        public enum State { notStarted, inProgress, finished }
        private State state = State.notStarted;
        private Set set;
        private Dictionary<uint, uint> setScore { get; set; }
        public Match(Player firstPlayer, Player secondPlayer)
        {
            this.set = new Set(firstPlayer, secondPlayer);
            this.setScore = new Dictionary<uint, uint>
            {
                { firstPlayer.id, 0},
                { secondPlayer.id, 0}
            };
        }
        public void AddScore(Player player)
        {
            if (state == State.finished)
            {
                return;
            }
            if (state == State.notStarted)
            {
                state = State.inProgress;
            }
            string pointScore = this.set.AddScore(player);
            if (pointScore == "win")
            {
                this.set.ResetScore();
                setScore[player.id]++;
            }
        }
        public State GetState()
        {
            return state;
        }
        public Dictionary<uint, List<string>> getScore()
        {
            Dictionary<uint, List<string>> totalScore = new Dictionary<uint, List<string>>();
            Dictionary<uint, List<string>> pointScore = this.set.getScore();
            foreach (uint playerID in pointScore.Keys)
            {
                List<string> score = new List<string> { pointScore[playerID][0], pointScore[playerID][1], setScore[playerID].ToString() };
                totalScore.Add(playerID, score);
            }
            return totalScore;
        }

    }
}
