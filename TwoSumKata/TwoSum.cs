namespace TwoSumKata;

public class TwoSum
{
    public static int[] GetTwoSum(int[] input, int target)
    {
        var dict = new Dictionary<int, int>();
        
        for (var i = 0; i < input.Length; i++)
        {
            var complement = target - input[i];
            if (dict.TryGetValue(complement, out var index) && index != i)
            {
                return [i, index];
            }

            if (!dict.ContainsKey(input[i]))
            {
                dict[input[i]] = i;
            }
        }

        return [];
    }
}