using System;

namespace Tennis
{
    public class TennisGame
    {
        private Player _player1;
        private Player _player2;
        private const int scoreDiffForWinning = 20;

        public TennisGame(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void PlayerScored(Player player)
        {
            if (player.Score > 40 && GetScoreDifference() == scoreDiffForWinning)
            {
                throw new InvalidOperationException("Game over");
            }
            player.Scores();          
        }

        public string GetScore()
        {
            var leader = GetLeadPlayer();
            
            //scores are equal
            if (leader == null)
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
                return SimpleScore();
            }

            if (leader.Score <= 40)
            {
                return SimpleScore();
            }

            var isAdvantage = GetScoreDifference() < scoreDiffForWinning;
            if (isAdvantage)
            {
                return leader.Name + " advantage";
            }
            return leader.Name + " win";
        }

        #region private
        private int GetScoreDifference()
        {
            var leader = GetLeadPlayer();
            return (leader != null) ? leader.Score - GetNotLeadPlayer(leader).Score : 0;
        }

        private Player GetLeadPlayer()
        {
            if (_player1.Score > _player2.Score)
            {
                return _player1;
            }
            if (_player2.Score > _player1.Score)
            {
                return _player2;
            }
            return null;
        }

        private Player GetNotLeadPlayer(Player leader)
        {
            return leader == _player1 ? _player2 : _player1;
        }

        private string SimpleScore()
        {
            return $"{_player1.GetScore()}-{_player2.GetScore()}";
        }
        #endregion
    }
}
