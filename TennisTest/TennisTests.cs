using Shouldly;
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

        [Fact]
        public void GetScore_Start_Shouldbe15Love()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);


            //Act
            game.PlayerScored(player1);
            var score = game.GetScore();

            //Assert
            score.ShouldBe("15-love");
        }

        [Fact]
        public void GetScore_Start_Shouldbe15_15()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);


            //Act
            game.PlayerScored(player1);
            game.PlayerScored(player2);
            var score = game.GetScore();

            //Assert
            score.ShouldBe("15-15");
        }

        [Theory]
        [InlineData(1, 2, "15-30")]
        [InlineData(1, 3, "15-40")]
        [InlineData(2, 1, "30-15")]
        [InlineData(3, 1, "40-15")]
        public void GetScore_ShouldShouldReturnExpectedValue(int player1ScoredCount, int player2ScoredCount, string score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            for (int i = 0; i < player1ScoredCount; i++)
            {
                game.PlayerScored(player1);
            }

            for (int i = 0; i < player2ScoredCount; i++)
            {
                game.PlayerScored(player2);
            }

            var result = game.GetScore();

            //Assert
            result.ShouldBe(score);
        }


        //[Theory]
        //[InlineData(30, 40)]
        //[InlineData(40, 1)]
        //[InlineData(1, 2)]
        //public void GetScore_ShouldbDeuse(int player1Score, int player2Score)
        //{
        //    //Arrange
        //    var player1 = new Player("Player1");
        //    var player2 = new Player("Player2");
        //    var game = new TennisGame(player1, player2);
        //    player1.Score = player1Score;
        //    player2.Score = player2Score;
        //    //Act
        //    game.SetScore(player1.Name);
        //    var score = game.GetScore();

        //    //Assert
        //    score.ShouldBe("deuse");
        //}

        //[Theory]
        //[InlineData(1, 40)]
        //[InlineData(40, 0)]
        //public void GetScore_Player1ShouldWin(int player1Score, int player2Score)
        //{
        //    //Arrange
        //    var player1 = new Player("Player1");
        //    var player2 = new Player("Player2");
        //    var game = new TennisGame(player1, player2);
        //    player1.Score = player1Score;
        //    player2.Score = player2Score;
        //    //Act
        //    game.SetScore(player1.Name);
        //    var score = game.GetScore();

        //    //Assert
        //    score.ShouldBe("Player1 win");
        //}

        //[InlineData(40, 40)]
        //public void GetScore_Player1IShouldbenAdvantage(int player1Score, int player2Score)
        //{
        //    //Arrange
        //    var player1 = new Player("Player1");
        //    var player2 = new Player("Player2");
        //    var game = new TennisGame(player1, player2);
        //    player1.Score = player1Score;
        //    player2.Score = player2Score;
        //    //Act
        //    game.SetScore(player1.Name);
        //    var score = game.GetScore();

        //    //Assert
        //    score.ShouldBe("Player1 in advantage");
        //}

    }
}
