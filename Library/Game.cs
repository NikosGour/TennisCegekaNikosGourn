namespace TennisCegekaNikosGourn.Library;

internal class Game
{
    int homeTeamSets;
    int awayTeamSets;

    int homeTeamPoints;
    int awayTeamPoints;

    public Game(Points homeTeamPoints, Points awayTeamPoints) : this()
    {
    }
    public Game(int homeTeamSets, int awayTeamSets) : this(Points.LOVE, Points.LOVE)
    {
    }

    public Game(Points homeTeamPoints, Points awayTeamPoints, int homeTeamSets, int awayTeamSets) : this(homeTeamPoints, awayTeamPoints)
    {
    }

    public Game()
    {
    }


    internal void TeamScores(Teams team)
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
