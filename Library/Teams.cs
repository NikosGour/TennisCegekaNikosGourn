namespace TennisCegekaNikosGourn.Library;

public enum Teams
{
    HOME,
    AWAY
}

public static class TeamsExtensions
{
    public static Teams GetOtherTeam(this Teams team)
    {
        return team == Teams.HOME ? Teams.AWAY : Teams.HOME;
    }
}
