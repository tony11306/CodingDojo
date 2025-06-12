namespace NextBiggerNumberWithTheSameDigitsKata;

public static class NextBiggerNumberWithTheSameDigits
{
    private const long MaxNumber = 2147483647;

    public static long NextBiggerNumber(long n)
    {
        var nString = n.ToString();
        var resultString = NextBiggerNumber(nString);

        Int64.TryParse(resultString, out var result);
        
        return result > MaxNumber
            ? -1
            : result;
    }

    private static string NextBiggerNumber(string numberString)
    {
        if (numberString.Length <= 1)
        {
            return "-1";
        }

        var subString = numberString[1..];
        var subNextGreater = NextBiggerNumber(subString);

        if (subNextGreater != "-1")
        {
            return numberString[0] + subNextGreater;
        }

        subString = new string(subString.Reverse().ToArray());

        for (var i = 0; i < subString.Length; ++i)
        {
            if (numberString[0] >= subString[i])
            {
                continue;
            }

            var nextGreater = subString[i];
            var remaining = subString[..i] + numberString[0] +subString[(i + 1)..];

            return nextGreater + remaining;
        }

        return "-1";
    }
}
