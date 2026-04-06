using System.Diagnostics;

namespace TennisCegekaNikosGourn.Library;

public enum Points
{
    LOVE,
    FIFTEEN,
    THIRTY,
    FORTY,
    ADVANTAGE
}
public static class PointsExtensions
{
    public static string toString(this Points points)
    {
        return points switch
        {
            Points.LOVE => "0",
            Points.FIFTEEN => "15",
            Points.THIRTY => "30",
            Points.FORTY => "40",
            Points.ADVANTAGE => "ADV",
            _ => throw new UnreachableException($"Invalid points: {Points.ADVANTAGE}"),
        };
    }
}
