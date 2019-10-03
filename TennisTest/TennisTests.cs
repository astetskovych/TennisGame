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
        [InlineData(2, 2, "30-30")]
        [InlineData(2, 3, "30-40")]
        [InlineData(3, 2, "40-30")]
        public void GetScore_ShouldShouldReturnExpectedValue(int player1ScoredCount, int player2ScoredCount, string score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            int i = 0, j = 0;
            for (; i < player1ScoredCount || j < player2ScoredCount; j++, i++)
            {
                if (i < player1ScoredCount)
                {
                    game.PlayerScored(player1);
                }
                if (j < player2ScoredCount)
                {
                    game.PlayerScored(player2);
                }
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
                game.PlayerScored(player2);
            }

            var result = game.GetScore();

            //Assert
            result.ShouldBe("deuse");
        }

        [Fact]
        public void GetScore_Player1ShouldWinWithoutDeuse()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            game.PlayerScored(player1);
            game.PlayerScored(player2);
            game.PlayerScored(player1);
            game.PlayerScored(player1);
            game.PlayerScored(player2);
            game.PlayerScored(player1);

            var result = game.GetScore();

            //Assert
            result.ShouldBe("Player1 win");
        }

        [Fact]
        public void GetScore_Player2ShouldWinWithoutDeuse()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            game.PlayerScored(player2);
            game.PlayerScored(player1);
            game.PlayerScored(player2);
            game.PlayerScored(player2);
            game.PlayerScored(player1);
            game.PlayerScored(player2);

            var result = game.GetScore();

            //Assert
            result.ShouldBe("Player2 win");
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
            for (int i = 0; i < player2Score; i++)
            {
                game.PlayerScored(player1);
                game.PlayerScored(player2);
            }

            game.PlayerScored(player1);

            var result = game.GetScore();

            //Assert
            result.ShouldBe("Player1 advantage");
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(10)]
        [InlineData(100)]
        public void GetScore_Player2ShouldBeInAdvantage(int player2Score)
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            for (int i = 0; i < player2Score; i++)
            {
                game.PlayerScored(player1);
                game.PlayerScored(player2);
            }

            game.PlayerScored(player2);

            var result = game.GetScore();

            //Assert
            result.ShouldBe("Player2 advantage");
        }

        [Fact]
        public void GetScore_Player1ShouldWinAfterAdvantage()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            game.PlayerScored(player1);
            game.PlayerScored(player2);
            game.PlayerScored(player1);
            game.PlayerScored(player2);
            game.PlayerScored(player1);
            game.PlayerScored(player2);
            game.PlayerScored(player1);
            game.PlayerScored(player1);

            var result = game.GetScore();

            //Assert
            result.ShouldBe("Player1 win");
        }

        [Fact]
        public void GetScore_Player2ShouldWinAfterAdvantage()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            game.PlayerScored(player2);
            game.PlayerScored(player1);
            game.PlayerScored(player1);
            game.PlayerScored(player2);
            game.PlayerScored(player2);
            game.PlayerScored(player1);
            game.PlayerScored(player2);
            game.PlayerScored(player2);

            var result = game.GetScore();

            //Assert
            result.ShouldBe("Player2 win");
        }

        [Fact]
        public void GetScore_Player2OverScores_ShouldThrowError()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            game.PlayerScored(player2); // 0-15
            game.PlayerScored(player1); // 15-15
            game.PlayerScored(player1); // 30-15
            game.PlayerScored(player2); // 30-30
            game.PlayerScored(player2); // 30-40
            game.PlayerScored(player1); // 40-40
            game.PlayerScored(player2); // advantage 2
            game.PlayerScored(player2); // player 2 wins

            Assert.Throws<InvalidOperationException>(() => game.PlayerScored(player2));
        }

        [Fact]
        public void GetScore_Player1OverScores_ShouldThrowError()
        {
            //Arrange
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var game = new TennisGame(player1, player2);

            //Act
            game.PlayerScored(player2); // 0-15
            game.PlayerScored(player1); // 15-15
            game.PlayerScored(player1); // 30-15
            game.PlayerScored(player2); // 30-30
            game.PlayerScored(player2); // 30-40
            game.PlayerScored(player1); // 40-40
            game.PlayerScored(player1); // advantage 1
            game.PlayerScored(player1); // player 1 wins

            Assert.Throws<InvalidOperationException>(() => game.PlayerScored(player1));
        }
    }
}
