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

        game.PlayerScores(pointScoringTeam);

        Assert.Equal(expectedPoints, game.GetScore(pointScoringTeam));
        Assert.Equal(pointScoringTeam == Teams.HOME ? awayPlayerPoints : homePlayerPoints, game.GetScore(pointScoringTeam.GetOtherTeam()));
    }
}
