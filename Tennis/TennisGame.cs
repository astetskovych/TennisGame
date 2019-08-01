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
            if (_player1.Score == 40 && _player2.Score == 40)
            {
                return "deuse";
            }
            if (_player1.Score == 40 && _player2.Score == 40)
            {
                return "deuse";
            }
            if (_player1.Score > 40 && _player2.Score <= 30)
            {
                return _player1.Name + " win";
            }
          
            return $"{_player1.GetScore()}-{_player2.GetScore()}";
            throw new Exception();
        }

        public void PlayerScored(Player player)
        {
            player.Scores();
        }
    }
}
