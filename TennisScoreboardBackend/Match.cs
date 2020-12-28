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
        private Dictionary<uint, List<string>> setHistory;
        private uint matchNumber;
        private List<string> score;
        private Player firstPlayer;
        private Player secondPlayer;
        private Player winner;

        public Match(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.set = new Set(firstPlayer, secondPlayer);
            this.setScore = new Dictionary<uint, uint>
            {
                { firstPlayer.id, 0},
                { secondPlayer.id, 0}
            };
            this.setHistory = new Dictionary<uint, List<string>>
            {
                { firstPlayer.id, new List<string>{"0","0","0"}},
                { secondPlayer.id, new List<string>{"0","0","0"}}
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
            matchNumber = 0;
            foreach (uint playerID in this.setScore.Keys)
            {
                matchNumber += setScore[playerID];
            }
            bool win;
            string pointScore = this.set.AddScore(player, out win);
            Player otherPlayer = player.id == firstPlayer.id ? secondPlayer : firstPlayer;
            this.setHistory[player.id][(int)matchNumber] = pointScore;
            this.setHistory[otherPlayer.id][(int)matchNumber] = this.set.getScore()[otherPlayer.id][1];
            if (win)
            {
                setScore[player.id]++;
                this.set.ResetScore();
                if (setScore[player.id] > 1)
                {
                    this.state = State.finished;
                    this.winner = player;
                }
                
            }
        }
        public State GetState()
        {
            return state;
        }
        public Player GetWinner()
        {
            return winner;
        }
        public Dictionary<uint, List<string>> getScore()
        {
            Dictionary<uint, List<string>> totalScore = new Dictionary<uint, List<string>>();
            Dictionary<uint, List<string>> pointScore = this.set.getScore();

            foreach (uint playerID in pointScore.Keys)
            {
                score = new List<string> { pointScore[playerID][0], setHistory[playerID][0], setHistory[playerID][1], setHistory[playerID][2], setScore[playerID].ToString() };
                totalScore.Add(playerID, score);
            }
 
            return totalScore;
        }

    }
}
