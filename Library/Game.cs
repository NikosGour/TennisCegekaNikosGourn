namespace TennisCegekaNikosGourn.Library;

internal class Game
{
    private int homeTeamSets = 0;
    private int awayTeamSets = 0;

    private Points homeTeamPoints = Points.LOVE;
    private Points awayTeamPoints = Points.LOVE;

    public Game(Points homeTeamPoints, Points awayTeamPoints) : this()
    {
        this.homeTeamPoints = homeTeamPoints;
        this.awayTeamPoints = awayTeamPoints;
    }
    public Game(int homeTeamSets, int awayTeamSets) : this(Points.LOVE, Points.LOVE)
    {
        this.homeTeamSets = homeTeamSets;
        this.awayTeamSets = awayTeamSets;
    }

    public Game(Points homeTeamPoints, Points awayTeamPoints, int homeTeamSets, int awayTeamSets) : this(homeTeamPoints, awayTeamPoints)
    {
        this.homeTeamSets = homeTeamSets;
        this.awayTeamSets = awayTeamSets;
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
