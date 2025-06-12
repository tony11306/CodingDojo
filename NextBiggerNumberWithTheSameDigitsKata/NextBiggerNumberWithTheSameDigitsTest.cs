using NextBiggerNumberWithTheSameDigitsKata;

namespace NextBiggerNumberWithTheSameDigitsKata;

public class NextBiggerNumberWithTheSameDigitsTest
{
    private long _actual;

    [TestCase(1, -1, TestName = "single digit")]
    [TestCase(12, 21, TestName = "two digits")]
    [TestCase(2147483486, -1, TestName = "out of bound result")]
    [TestCase(12345, 12354, TestName = "ascending case")]
    [TestCase(54321, -1, TestName = "descending case")]
    [TestCase(230241, 230412, TestName = "general case")]
    public void given_number_when_getting_next_bigger_element_then_should_return_expected(long input, long expected)
    {
        WhenGettingNextBiggerNumber(input);
        ResultShouldBe(expected);
    }

    private void ResultShouldBe(long expected)
    {
        Assert.That(_actual, Is.EqualTo(expected));
    }

    private void WhenGettingNextBiggerNumber(long input)
    {
        _actual = NextBiggerNumberWithTheSameDigits.NextBiggerNumber(input);
    }
}