using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Player
    {
        public string Name { get; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        internal void Scores()
        {
            if (Score == 0)
            {
                Score = 15;
            }
            else if (Score == 15)
            {
                Score = 30;
            }
            else if (Score == 30)
            {
                Score = 40;
            }
            else if (Score == 40)
            {
                Score = 41;
            }
            else if (Score > 40)
            {
                Score++;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal string GetScore()
        {
            if (Score != 0)
            {
                return Score.ToString();
            }
            return "love";
        }
    }
}
