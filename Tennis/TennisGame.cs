using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class TennisGame
    {
        private Player _player1;
        private Player _player2;

        public TennisGame(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public string GetScore()
        {
            string score;
            var leader = GetLeadPlayer();
            if (leader != null && leader.Score > 40)
            {
                score = CheckOnEndGame(leader);
                if (score != string.Empty)
                {
                    return score;
                }
            }
            else if (leader == null)
            {
                var scoreAll = _player1.Score;
                if (scoreAll == 0)
                {
                    return "love all";
                }
                if (scoreAll >= 40)
                {
                    return "deuse";
                }
                
            }
          

            //if (_player1.Score == 0 && _player2.Score == 0)
            //{
            //    return "love all";
            //}
            //if (_player1.Score == 40 && _player2.Score == 40)
            //{
            //    return "deuse";
            //}
            //if (_player1.Score == 40 && _player2.Score == 40)
            //{
            //    return "deuse";
            //}
         
            if (_player1.Score == 41 && _player2.Score == 40)
            {
                return _player1.Name + " advantage";
            }

            return $"{_player1.GetScore()}-{_player2.GetScore()}";
            throw new Exception();
        }

        private Player GetLeadPlayer()
        {
            if (_player1.Score > _player2.Score)
            {
                return _player1;
            }
            else if (_player2.Score > _player1.Score)
            {
                return _player2;
            }
            return null;
        }

        private Player GetNotLeadPlayer(Player leader)
        {
            if (leader == _player1)
            {
                return _player2;
            }
            return _player2;
        }

        private string CheckOnEndGame(Player leader)
        {
            var notLeader = GetNotLeadPlayer(leader);
            if (leader.Score > 40 && (notLeader.Score <= 30 || ((leader.Score - notLeader.Score) > 1)))
            {
                return leader.Name + " win";
            }
            return string.Empty;
        }

        public void PlayerScored(Player player)
        {
            player.Scores();
        }
    }
}
