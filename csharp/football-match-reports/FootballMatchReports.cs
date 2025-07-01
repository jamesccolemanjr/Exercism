public static class PlayAnalyzer
{
    private static Dictionary<int, string> _playerPosNumbers = new Dictionary<int, string>
    {
        { 1, "goalie"},
        { 2, "left back" }, 
        { 3, "center back" },
        { 4, "center back" },
        { 5, "right back" },
        { 6, "midfielder" },
        { 7, "midfielder" },
        { 8, "midfielder" },
        { 9, "left wing" },
        {10, "striker" },
        {11, "right wing" }

    };

    public static string AnalyzeOnField(int shirtNum)
    {
        return (shirtNum > 11 || shirtNum < 1) ? "UNKNOWN" : _playerPosNumbers[shirtNum];
    }

    public static string AnalyzeOffField(object report)
    {
        switch(report)
        {
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            case Foul foul:
                return "The referee deemed a foul.";
            case Incident incident:
                return "An incident happened.";
            case Manager manager:
                return (manager.Club == null) ? manager.Name : $"{manager.Name} ({manager.Club})";
            default:
                if(report.GetType() == typeof(int))
                {
                    return $"There are {report.ToString()} supporters at the match.";
                } else if (report.GetType() == typeof(string))
                {
                    return report?.ToString() ?? "";
                } else
                {
                    return "";
                }

        }
    }
}
