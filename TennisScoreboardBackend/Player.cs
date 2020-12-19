using System;

namespace TennisScoreboardBackend
{
    public class Player
    {
        private static readonly Random rand = new Random();
        public string name { get; }
        public uint id { get; }
        public Player(string name)
        {
            this.name = name;
            this.id = (uint)rand.Next();
        }
    }
}
