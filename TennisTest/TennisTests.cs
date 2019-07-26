using System;
using Tennis;
using Xunit;

namespace TennisTest
{
    public class TennisTests
    {
        [Fact]
        public void GetScore_Start_ShouldbeLoveAll()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            var score = game.GetScore();

            //Assert
            score.ShouldBe("love all");
        }

        [Theory]
        [InlineData (0, 0, "Love-15")]
        [InlineData(0, 15, "Love-30")]
        [InlineData(0, 30, "Love-40")]
        [InlineData(15, 0, "15-15")]
        [InlineData(15, 15, "15-30")]
        [InlineData(15, 30, "15-40")]
        [InlineData(30, 0, "30-15")]
        public void GetScore_ShouldShouldReturnExpectedValue(int player1Score, int player2Score, string score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);
            player1.Score = player1Score;
            player2.Score = player2Score;
            //Act
            game.SetScore(player2.Name);
            var score = game.GetScore()

            //Assert
            score.ShouldBe(score);

        }


        [Theory]
        [InlineData(30, 40)]
        [InlineData(40, 1)]
        [InlineData(1, 2)]
        public void GetScore_ShouldbDeuse(int player1Score, int player2Score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);
            player1.Score = player1Score;
            player2.Score = player2Score;
            //Act
            game.SetScore(player1.Name);
            var score = game.GetScore()

            //Assert
            score.ShouldBe("deuse");
        }

        [Theory]
        [InlineData(1, 40)]
        [InlineData(40, 0)]
        public void GetScore_Player1ShouldWin(int player1Score, int player2Score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);
            player1.Score = player1Score;
            player2.Score = player2Score;
            //Act
            game.SetScore(player1.Name);
            var score = game.GetScore()

            //Assert
            score.ShouldBe("Player1 win");
        }

        [InlineData(40, 40)]
        public void GetScore_Player1IShouldbenAdvantage(int player1Score, int player2Score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);
            player1.Score = player1Score;
            player2.Score = player2Score;
            //Act
            game.SetScore(player1.Name);
            var score = game.GetScore()

            //Assert
            score.ShouldBe("Player1 in advantage");
        }

    }
}
