using System;

namespace TennisScoreboardBackend
{
    /// <summary>
    /// Class Player containes name and (random) id
    /// </summary>
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
