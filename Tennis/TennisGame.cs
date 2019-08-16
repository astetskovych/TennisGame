using System;

namespace Tennis
{
    public class TennisGame
    {
        private Player _player1;
        private Player _player2;
        private const int scoreDiffForWinning = 2;

        public TennisGame(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public string GetScore()
        {
            var leader = GetLeadPlayer();
            var isAdvantage = (leader.Score - GetNotLeadPlayer(leader).Score) < scoreDiffForWinning;

            //scores are equals
            if (leader == null)
            {
                var scoreAll = _player1.Score;
                if (scoreAll == 0)
                {
                    return "love all";
                }
                else if (scoreAll >= 40)
                {
                    return "deuse";
                }
                return SimpleScore();
            }

            if (leader.Score <= 40)
            {
                return SimpleScore();
            }

            //advanatage
            if (isAdvantage)
            {
                return leader.Name + " advantage";
            }
            
            //win
            return leader.Name + " win";
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
            return _player1;
        }

        private string SimpleScore()
        {
            return $"{_player1.GetScore()}-{_player2.GetScore()}";
        }

        public void PlayerScored(Player player)
        {
            player.Scores();
        }
    }
}
