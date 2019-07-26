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
    }
}
