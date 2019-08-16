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
            string score;
            var leader = GetLeadPlayer();

            if (leader != null)
            {
                var isAdvantage = (leader.Score - GetNotLeadPlayer(leader).Score) < scoreDiffForWinning;

                //advanatage
                if (isAdvantage)
                {
                    return leader.Name + " advantage";
                }

                if (leader.Score <= 40)
                {
                    return SimpleScore();
                }

                score = CheckOnEndGame(leader);

                //win
                if (score != string.Empty)
                {
                    return score;
                }
            }

            //scores are equal
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

        private string CheckOnEndGame(Player leader)
        {
            var notLeader = GetNotLeadPlayer(leader);
            if (leader.Score > 40 && (notLeader.Score <= 30 || ((leader.Score - notLeader.Score) > 1)))
            {
                return leader.Name + " win";
            }
            return string.Empty;
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
