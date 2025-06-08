namespace CountingDuplicates;

public static class CountingDuplicates
{
    public static int DuplicateCount(string str)
    {
        var dict = new Dictionary<char, int>();

        foreach (var c in str.ToLower())
        {
            if (!dict.TryAdd(c, 1))
            {
                dict[c]++;
            }
        }

        return dict.Select(x => x.Value).Count(x => x > 1);
    }
}