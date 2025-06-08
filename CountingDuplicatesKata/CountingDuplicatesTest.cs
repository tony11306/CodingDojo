
namespace CountingDuplicates;

public class CountingDuplicatesTest
{
    private int _actual;

    [SetUp]
    public void SetUp()
    { }

    [Test]
    public void given_empty_string_when_counting_duplicates_then_should_return_zero()
    {
        WhenCountingDuplicates("");
        ResultShouldBe(0);
    }

    [TestCase("abcde")]
    [TestCase("qwG2jkB")]
    public void given_non_duplicate_string_when_counting_duplicates_then_should_return_zero(string input)
    {
        WhenCountingDuplicates(input);
        ResultShouldBe(0);
    }

    [TestCase("aabbcde", 2)]
    [TestCase("CCDDEEFG", 3)]
    public void given_same_case_adjacent_duplicate_string_when_counting_duplicates_then_should_return_expected_value(string input, int expected)
    {
        WhenCountingDuplicates(input);
        ResultShouldBe(expected);
    }

    [TestCase("AaBbcDe", 2)]
    [TestCase("CCddEeFg", 3)]
    public void given_diff_case_adjacent_duplicate_string_when_counting_duplicates_then_should_return_expected_value(string input, int expected)
    {
        WhenCountingDuplicates(input);
        ResultShouldBe(expected);
    }

    [TestCase("AbacBCdcc", 3)]
    [TestCase("Indivisibility", 1)]
    [TestCase("Indivisibilities", 2)]
    public void given_diff_case_non_adjacent_duplicate_string_when_counting_duplicates_then_should_return_expected_value(string input, int expected)
    {
        WhenCountingDuplicates(input);
        ResultShouldBe(expected);
    }

    private void WhenCountingDuplicates(string input)
    {
        _actual = CountingDuplicates.DuplicateCount(input);
    }

    private void ResultShouldBe(int expected)
    {
        Assert.That(_actual, Is.EqualTo(expected));
    }
}