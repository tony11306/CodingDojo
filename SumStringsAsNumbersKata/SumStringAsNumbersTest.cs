namespace SumStringsAsNumbersKata;

public class SumStringAsNumbersTest
{
    private string _actual;

    [TestCase("0", "0", "0", TestName = "zero add zero")]
    [TestCase("1", "2", "3", TestName = "single digit add no carry")]
    [TestCase("9", "1", "10", TestName = "single digit add with carry")]
    [TestCase("123", "4567", "4690", TestName = "multi digits a < b")]
    [TestCase("223457", "1235", "224692", TestName = "multi digits add a > b")]
    [TestCase("00223457", "1235", "224692", TestName = "leading zero input")]
    public void given_two_digits_string_when_adding_them_then_should_return_expected(string first, string second, string expected)
    {
        WhenAddingStrings(first, second);

        ResultShouldBe(expected);
    }

    private void ResultShouldBe(string expected)
    {
        Assert.That(_actual, Is.EqualTo(expected));
    }

    private void WhenAddingStrings(string first, string second)
    {
        _actual = SumStringAsNumbers.SumStrings(first, second);
    }
}