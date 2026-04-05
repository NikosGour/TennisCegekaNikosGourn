using TennisCegekaNikosGourn.Library;
using Xunit;

namespace TennisCegekaNikosGourn.Tests;

public class GameTests
{
    [Fact]
    public void TestScorePoint()
    {
        Game game = new Game();

        game.PlayerScores(Teams.HOME);

        Assert.Equal(Points.FIFTEEN, game.GetScore(Teams.HOME));
    }
}
