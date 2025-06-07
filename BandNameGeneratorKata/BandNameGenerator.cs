namespace BandNameGenerator;

public static class BandNameGenerator
{
    public static string GenerateBandName(string str)
    {
        if (!IsStartAndEndTheSame(str))
        {
            return CapitalizeString(RepeatString(str));
        }

        return $"The {CapitalizeString(str)}";

    }

    private static string RepeatString(string str)
    {
        return string.Concat(str, str.Substring(1));
    }

    private static string CapitalizeString(string str)
    {
        return char.ToUpper(str.First()) + str.Substring(1);
    }

    private static bool IsStartAndEndTheSame(string str)
    {
        return str.First() != str.Last();
    }
}