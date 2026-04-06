using TennisCegekaNikosGourn.Library;

namespace TennisCegekaNikosGourn;

internal class Program
{
    public static void Main(string[] args)
    {
        Game game = new(Points.FORTY, Points.THIRTY, 3, 2);
        game.TeamScores(Teams.HOME);
        if (game.hasWonGame(Teams.HOME))
        {
            Console.WriteLine("Home team wins the game!");
        }
        else if (game.hasWonGame(Teams.AWAY))
        {
            Console.WriteLine("Away team wins the game!");
        }
        else
        {
            Console.WriteLine("The game is still ongoing.");
        }
    }
}
