using System.Collections.Generic;

namespace TennisScoreboardBackend
{
    /// <summary>
    /// Class Match manages the amount of sets won by each player (1-2)
    /// </summary>
    public class Match
    {
        public enum State { notStarted, inProgress, finished }
        private State state = State.notStarted;
        private readonly Set set;
        private Dictionary<uint, uint> setScore { get; set; }

        // Variable that tracks the of each player in each set
        private readonly Dictionary<uint, List<string>> setHistory;
        private uint matchNumber;
        private List<string> score;
        private readonly Player firstPlayer;
        private readonly Player secondPlayer;
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

        /// <summary>
        /// Add score to a player
        /// </summary>
        /// <param name="player">the player who will get a point</param>
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
            string pointScore = this.set.AddScore(player, out bool win);
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

        ///<summary>return the total score of both players</summary>
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
