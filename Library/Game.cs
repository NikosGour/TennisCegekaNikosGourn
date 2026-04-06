using System.Diagnostics;

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
        Points scoringTeamPoints = GetScore(team);
        Points nonScoringTeamPoints = GetScore(team.GetOtherTeam());

        int scoringTeamSets = GetSets(team);

        if (hasWonGame(team) || hasWonGame(team.GetOtherTeam()))
        {
            throw new InvalidOperationException("The game has already been won");
        }

        var (newScoringPoints, newNonScoringPoints, newScoringSets) = (scoringTeamPoints: scoringTeamPoints, nonScoringTeamPoints: nonScoringTeamPoints) switch
        {
            { scoringTeamPoints: Points.LOVE } => (Points.FIFTEEN, nonScoringTeamPoints, scoringTeamSets),
            { scoringTeamPoints: Points.FIFTEEN } => (Points.THIRTY, nonScoringTeamPoints, scoringTeamSets),
            { scoringTeamPoints: Points.THIRTY } => (Points.FORTY, nonScoringTeamPoints, scoringTeamSets),
            { scoringTeamPoints: Points.FORTY, nonScoringTeamPoints: Points.FORTY } => (Points.ADVANTAGE, nonScoringTeamPoints, scoringTeamSets),
            { scoringTeamPoints: Points.FORTY, nonScoringTeamPoints: Points.ADVANTAGE } => (Points.FORTY, Points.FORTY, scoringTeamSets),
            { scoringTeamPoints: Points.FORTY } => (Points.LOVE, Points.LOVE, scoringTeamSets + 1),
            { scoringTeamPoints: Points.ADVANTAGE } => (Points.LOVE, Points.LOVE, scoringTeamSets + 1),
            _ => throw new UnreachableException($"The following state is unreachable: Home Team: {homeTeamSets} | {homeTeamPoints.toString()}, Away Team: {awayTeamSets} | {awayTeamPoints.toString()}"),
        };

        if (team == Teams.HOME)
        {
            homeTeamPoints = newScoringPoints;
            awayTeamPoints = newNonScoringPoints;
            homeTeamSets = newScoringSets;
        }
        else
        {
            awayTeamPoints = newScoringPoints;
            homeTeamPoints = newNonScoringPoints;
            awayTeamSets = newScoringSets;
        }
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
