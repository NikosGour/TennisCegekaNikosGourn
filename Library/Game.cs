namespace TennisCegekaNikosGourn.Library;

internal class Game
{
    public Game(Points homePlayerPoints, Points awayPlayerPoints) : this()
    {
    }
    public Game(int homePlayerSets, int awayPlayerSets) : this(Points.LOVE, Points.LOVE)
    {
    }

    public Game(Points homePlayerPoints, Points awayPlayerPoints, int homePlayerSets, int awayPlayerSets) : this(homePlayerPoints, awayPlayerPoints)
    {
    }

    public Game()
    {
    }


    internal void PlayerScores(Teams team)
    {
        throw new NotImplementedException();
    }

    internal Points GetScore(Teams team)
    {
        throw new NotImplementedException();
    }

    internal int GetSets(Teams pointScoringTeam)
    {
        throw new NotImplementedException();
    }

    internal bool hasWonGame(Teams pointScoringTeam)
    {
        throw new NotImplementedException();
    }
}
