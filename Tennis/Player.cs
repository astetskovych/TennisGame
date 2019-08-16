using System;
using System.Collections.Generic;

namespace Tennis
{
    public class Player
    {
        private readonly List<int> _scoreCollection = new List<int> { 0, 15, 30, 40 };
        public string Name { get; }
        public int Score { get; private set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        internal void Scores()
        {
            if (Score >= 40)
            {
                Score++;
            }
            else if (Score < 40)
            {
                Score = _scoreCollection[_scoreCollection.IndexOf(Score) + 1];
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal string GetScore()
        {
            return Score != 0 ? Score.ToString() : "love";
        }
    }
}
