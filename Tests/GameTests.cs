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
    public void TestScorePoint(Points homePlayerPoints, Points awayPlayerPoints, Points expectedPoints, Teams pointScoringTeam)
    {
        Game game = new(homePlayerPoints, awayPlayerPoints);

        game.PlayerScores(pointScoringTeam);

        Assert.Equal(expectedPoints, game.GetScore(pointScoringTeam));
        Assert.Equal(pointScoringTeam == Teams.HOME ? awayPlayerPoints : homePlayerPoints, game.GetScore(pointScoringTeam.GetOtherTeam()));
    }
}
