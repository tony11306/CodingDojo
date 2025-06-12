namespace SumStringsAsNumbersKata;

public class SumStringAsNumbers
{
    public static string SumStrings(string a, string b)
    {
        a = RemoveLeadingZeros(a);
        b = RemoveLeadingZeros(b);
        if (a.Length < b.Length)
        {
            (a, b) = (b, a);
        }
        
        var result = AddDigits(a, b, out var carry);

        result[0] = carry > 0 
            ? (char)('0' + carry) 
            : '0';
        
        return result[0] == '0' 
            ? new string(result)[1..] 
            : new string(result);
    }

    private static string RemoveLeadingZeros(string digits)
    {
        var index = 0;
        while (index < digits.Length && digits[index] == '0')
        {
            index++;
        }
        
        return index == digits.Length 
            ? "0" 
            : digits[index..];
    }

    private static char[] AddDigits(string a, string b, out int carry)
    {
        var result = new char[a.Length + 1];
        carry = 0;
        
        for (var i = 0; i < a.Length; i++)
        {
            var digitA = a[a.Length - 1 - i];
            var digitB = i < b.Length ? b[b.Length - 1 - i] : '0';
            result[result.Length - 1 - i] = AddDigit(digitA, digitB, ref carry);
        }

        return result;
    }

    private static char AddDigit(char a, char b, ref int carry)
    {
        var sum = (a - '0') + (b - '0') + carry;
        carry = sum / 10;
        return (char)('0' + sum % 10);
    }
}