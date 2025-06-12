namespace ContainsDuplicateII;

public class ContainsDuplicate2
{
    public static bool ContainsNearbyDuplicate(int[] nums, int k) {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (dict.TryGetValue(nums[i], out var duplicant) && i - duplicant <= k)
            {
                return true;
            }

            dict[nums[i]] = i;
        }

        return false;
    }
}