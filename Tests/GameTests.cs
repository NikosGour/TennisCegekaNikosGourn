using TennisCegekaNikosGourn.Library;
using Xunit;

namespace TennisCegekaNikosGourn.Tests;

public class GameTests
{
    [Theory]
    [InlineData(Points.LOVE, Points.LOVE, Points.FIFTEEN, Teams.HOME)]
    [InlineData(Points.FIFTEEN, Points.LOVE, Points.THIRTY, Teams.HOME)]
    [InlineData(Points.THIRTY, Points.LOVE, Points.FORTY, Teams.HOME)]
    [InlineData(Points.FORTY, Points.LOVE, Points.LOVE, Teams.HOME)]
    [InlineData(Points.LOVE, Points.LOVE, Points.FIFTEEN, Teams.AWAY)]
    [InlineData(Points.LOVE, Points.FIFTEEN, Points.THIRTY, Teams.AWAY)]
    [InlineData(Points.LOVE, Points.THIRTY, Points.FORTY, Teams.AWAY)]
    [InlineData(Points.LOVE, Points.FORTY, Points.LOVE, Teams.AWAY)]
    [InlineData(Points.FORTY, Points.FORTY, Points.ADVANTAGE, Teams.HOME)]
    [InlineData(Points.FORTY, Points.FORTY, Points.ADVANTAGE, Teams.AWAY)]
    public void TestScorePoint(Points homePlayerPoints, Points awayPlayerPoints, Points expectedPoints, Teams pointScoringTeam)
    {
        Game game = new(homePlayerPoints, awayPlayerPoints);
        Points expectedPointsNonScoringTeam = pointScoringTeam == Teams.HOME ? awayPlayerPoints : homePlayerPoints;

        game.PlayerScores(pointScoringTeam);

        Assert.Equal(expectedPoints, game.GetScore(pointScoringTeam));
        Assert.Equal(expectedPointsNonScoringTeam, game.GetScore(pointScoringTeam.GetOtherTeam()));
    }

    [Theory]
    [InlineData(Points.LOVE, Points.LOVE, 0, Teams.HOME)]
    [InlineData(Points.FIFTEEN, Points.LOVE, 0, Teams.HOME)]
    [InlineData(Points.THIRTY, Points.LOVE, 0, Teams.HOME)]
    [InlineData(Points.FORTY, Points.LOVE, 1, Teams.HOME)]
    [InlineData(Points.LOVE, Points.LOVE, 0, Teams.AWAY)]
    [InlineData(Points.LOVE, Points.FIFTEEN, 0, Teams.AWAY)]
    [InlineData(Points.LOVE, Points.THIRTY, 0, Teams.AWAY)]
    [InlineData(Points.LOVE, Points.FORTY, 1, Teams.AWAY)]
    [InlineData(Points.FORTY, Points.FORTY, 0, Teams.HOME)]
    [InlineData(Points.FORTY, Points.FORTY, 0, Teams.AWAY)]
    [InlineData(Points.ADVANTAGE, Points.FORTY, 1, Teams.HOME)]
    [InlineData(Points.FORTY, Points.ADVANTAGE, 1, Teams.AWAY)]
    public void TestScorePointSets(Points homePlayerPoints, Points awayPlayerPoints, int expectedSets, Teams pointScoringTeam)
    {
        Game game = new(homePlayerPoints, awayPlayerPoints);
        int expectedSetsNonScoringTeam = game.GetSets(pointScoringTeam.GetOtherTeam());

        game.PlayerScores(pointScoringTeam);

        Assert.Equal(expectedSets, game.GetSets(pointScoringTeam));
        Assert.Equal(expectedSetsNonScoringTeam, game.GetSets(pointScoringTeam.GetOtherTeam()));
    }

    [Theory]
    [InlineData(0, 0, false, Teams.HOME)]
    [InlineData(0, 1, false, Teams.HOME)]
    [InlineData(0, 0, false, Teams.AWAY)]
    [InlineData(0, 1, false, Teams.AWAY)]
    [InlineData(3, 0, true, Teams.HOME)]
    [InlineData(0, 3, false, Teams.HOME)]
    [InlineData(3, 0, false, Teams.AWAY)]
    [InlineData(0, 3, true, Teams.AWAY)]
    [InlineData(3, 2, true, Teams.HOME)]
    [InlineData(2, 3, true, Teams.AWAY)]
    [InlineData(3, 3, false, Teams.HOME)]
    [InlineData(3, 3, false, Teams.AWAY)]
    [InlineData(50, 50, false, Teams.HOME)]
    [InlineData(50, 50, false, Teams.AWAY)]
    [InlineData(50, 49, true, Teams.HOME)]
    [InlineData(49, 50, true, Teams.AWAY)]
    public void TestScorePointWinGame(int homePlayerSets, int awayPlayerSets, bool hasScoringTeamWon, Teams pointScoringTeam)
    {
        Points homePlayerPoints = pointScoringTeam == Teams.HOME ? Points.LOVE : Points.FORTY;
        Points awayPlayerPoints = pointScoringTeam == Teams.AWAY ? Points.LOVE : Points.FORTY;
        bool hasNonScoringTeamWon = !hasScoringTeamWon;
        Game game = new(homePlayerPoints, awayPlayerPoints, homePlayerSets, awayPlayerSets);

        game.PlayerScores(pointScoringTeam);

        Assert.Equal(hasScoringTeamWon, game.hasWonGame(pointScoringTeam));
        Assert.Equal(hasNonScoringTeamWon, game.hasWonGame(pointScoringTeam.GetOtherTeam()));
    }

    [Theory]
    [InlineData(0, 0, false, Teams.HOME)]
    [InlineData(0, 1, false, Teams.HOME)]
    [InlineData(0, 0, false, Teams.AWAY)]
    [InlineData(0, 1, false, Teams.AWAY)]
    [InlineData(4, 0, true, Teams.HOME)]
    [InlineData(0, 4, true, Teams.HOME)]
    [InlineData(4, 0, true, Teams.AWAY)]
    [InlineData(0, 4, true, Teams.AWAY)]
    [InlineData(3, 2, false, Teams.HOME)]
    [InlineData(2, 3, false, Teams.AWAY)]
    [InlineData(3, 3, false, Teams.HOME)]
    [InlineData(3, 3, false, Teams.AWAY)]
    [InlineData(50, 48, true, Teams.HOME)]
    [InlineData(48, 50, true, Teams.AWAY)]
    [InlineData(50, 49, false, Teams.HOME)]
    [InlineData(49, 50, false, Teams.AWAY)]
    public void TestScorePointAlreadyWonGame(int homePlayerSets, int awayPlayerSets, bool alreadyWonGame, Teams pointScoringTeam)
    {
        Game game = new(homePlayerSets, awayPlayerSets);


        if (alreadyWonGame)
        {
            Assert.Throws<InvalidOperationException>(() => game.PlayerScores(pointScoringTeam));
        }
        else
        {
            game.PlayerScores(pointScoringTeam);
        }
    }
}
