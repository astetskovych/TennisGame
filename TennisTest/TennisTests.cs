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


        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(10)]
        [InlineData(100)]
        public void GetScore_ShouldBeDeuse(int score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            for (int i = 0; i < score; i++)
            {
                game.PlayerScored(player1);
            }

            for (int i = 0; i < score; i++)
            {
                game.PlayerScored(player2);
            }

            var result = game.GetScore();

            //Assert
            result.ShouldBe("deuse");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void GetScore_Player1ShouldWinWithoutDeuse(int player2Score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            for (int i = 0; i < 4; i++)
            {
                game.PlayerScored(player1);
            }

            for (int i = 0; i < player2Score; i++)
            {
                game.PlayerScored(player2);
            }

            var result = game.GetScore();

            //Assert
            result.ShouldBe("Player1 win");
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(10)]
        [InlineData(100)]
        public void GetScore_Player1ShouldBeInAdvantage(int player2Score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            for (int i = 0; i < player2Score + 1; i++)
            {
                game.PlayerScored(player1);
            }

            for (int i = 0; i < player2Score; i++)
            {
                game.PlayerScored(player2);
            }

            var result = game.GetScore();

            //Assert
            result.ShouldBe("Player1 advantage");
        }

        [Fact]
        public void GetScore_Player1ShouldWinAfterAdvantage()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            for (int i = 0; i < 5; i++)
            {
                game.PlayerScored(player1);
            }

            for (int i = 0; i < 3; i++)
            {
                game.PlayerScored(player2);
            }

            var result = game.GetScore();

            //Assert
            result.ShouldBe("Player1 win");
        }
    }
}
