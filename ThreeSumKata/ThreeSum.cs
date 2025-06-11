namespace ThreeSumKata;

public class ThreeSum
{
    private Dictionary<int, List<List<int>>> _lookupTable;

    public IList<IList<int>> GetThreeSum(int[] nums)
    {
        var cleanedNums = SortAndRemoveDupMoreThanThreeTimes(nums);

        InitializeLookupTable(cleanedNums);

        var result = new List<List<int>>();
        for (var i = 0; i < cleanedNums.Count; ++i)
        {
            TryAddResult(cleanedNums, i, result);
        }

        return GetDistinctResult(result);
    }

    private static List<IList<int>> GetDistinctResult(List<List<int>> result)
    {
        var distinctResult = new HashSet<string>();
        var finalResult = new List<IList<int>>();

        foreach (var triplet in result)
        {
            var key = string.Join(",", triplet);
            if (distinctResult.Add(key))
            {
                finalResult.Add(triplet);
            }
        }

        return finalResult;
    }

    private void TryAddResult(List<int> cleanedNums, int i, List<List<int>> result)
    {
        if (!_lookupTable.TryGetValue(-cleanedNums[i], out var lists))
        {
            return;
        }

        foreach (var pair in lists)
        {
            if (IsSameIndex(pair, i))
            {
                continue;
            }

            var triplet = new List<int> { cleanedNums[i], cleanedNums[pair[0]], cleanedNums[pair[1]] };
            triplet.Sort();
            result.Add(triplet);
        }
    }

    private static bool IsSameIndex(List<int> pair, int i)
    {
        return pair[0] == i || pair[1] == i;
    }

    private static List<int> SortAndRemoveDupMoreThanThreeTimes(int[] nums)
    {
        return nums.GroupBy(x => x)
            .SelectMany(group => group.Take(3))
            .OrderBy(x => x)
            .ToList();
    }

    private void InitializeLookupTable(List<int> cleanedNums)
    {
        _lookupTable = new Dictionary<int, List<List<int>>>();

        for (var i = 0; i < cleanedNums.Count; ++i)
        {
            for (var j = i + 1; j < cleanedNums.Count; ++j)
            {
                var sum = cleanedNums[i] + cleanedNums[j];
                _lookupTable.TryAdd(sum, []);
                _lookupTable[sum].Add([i, j]);
            }
        }
    }
}
