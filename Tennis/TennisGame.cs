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
            if (_player1.Score == 0 && _player2.Score == 0)
            {
                return "love all";
            }
            //if (_player1.Score == 15 && _player2.Score == 0)
            //{
            //    return "15-love";
            //}
            //if (_player1.Score == 15 && _player2.Score == 15)
            //{
            //    return "15-15";
            //}
            return $"{_player1.GetScore()}-{_player2.GetScore()}";
            throw new Exception();
        }

        public void PlayerScored(Player player)
        {
            player.Scores();
        }
    }
}
