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
        return team switch
        {
            Teams.HOME => homeTeamPoints,
            Teams.AWAY => awayTeamPoints,
            _ => throw new ArgumentException("Invalid team")
        };
    }

    internal int GetSets(Teams team)
    {
        return team switch
    {
            Teams.HOME => homeTeamSets,
            Teams.AWAY => awayTeamSets,
            _ => throw new ArgumentException("Invalid team")
        };
    }

    internal bool hasWonGame(Teams team)
    {
        return team switch
    {
            Teams.HOME => homeTeamSets >= 4 && homeTeamSets - awayTeamSets >= 2,
            Teams.AWAY => awayTeamSets >= 4 && awayTeamSets - homeTeamSets >= 2,
            _ => throw new ArgumentException("Invalid team")
        };
    }
}
