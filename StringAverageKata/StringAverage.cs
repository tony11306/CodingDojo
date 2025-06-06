namespace StringAverageKata;

public static class StringAverage
{
    private static readonly Dictionary<string, int> NumberMap = new()
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    public static string AverageString(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return "n/a";
        }
        
        var numbers = str.Split(' ');
        var sum = 0;
        foreach(var number in numbers)
        {
            if (!NumberMap.ContainsKey(number))
            {
                return "n/a";
            }
            sum += ConvertToInt(number);
        }

        var average = sum / numbers.Length;
        return ConvertToString(average);
    }

    private static string ConvertToString(int number)
    {
        return NumberMap.FirstOrDefault(x => x.Value == number).Key;
    }

    private static int ConvertToInt(string number)
    {
        return NumberMap[number];
    }
}