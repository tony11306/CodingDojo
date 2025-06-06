namespace StringAverageKata;

public class StringAverageTest
{
    private string _actual;

    [SetUp]
    public void SetUp()
    {
        _actual = string.Empty;
    }

    [Test]
    public void given_empty_string_when_calculating_string_average_then_should_return_na()
    {
        const string input = "";
        const string expected = "n/a";

        WhenCalculatingStringAverage(input);
        Assert.That(_actual, Is.EqualTo(expected));
    }

    [TestCase("zero")]
    [TestCase("two")]
    [TestCase("seven")]
    public void given_one_text_number_when_calculating_string_average_then_should_return_itself(string input)
    {
        WhenCalculatingStringAverage(input);
        Assert.That(_actual, Is.EqualTo(input));
    }

    [TestCase("zero nine five two", "four")]
    [TestCase("four six two three", "three")]
    [TestCase("one two three four five", "three")]
    [TestCase("five four", "four")]
    [TestCase("zero zero zero zero zero", "zero")]
    [TestCase("one one eight one", "two")]
    public void given_multiple_text_numbers_when_calculating_string_average_then_should_return_average(string input, string expected)
    {
        WhenCalculatingStringAverage(input);
        Assert.That(_actual, Is.EqualTo(expected));
    }

    [TestCase("zero nine five two ten", "n/a")]
    [TestCase("eleven", "n/a")]
    public void given_invalid_text_number_when_calculating_string_average_then_should_return_na(string input, string expected)
    {
        WhenCalculatingStringAverage(input);
        Assert.That(_actual, Is.EqualTo(expected));
    }

    private void WhenCalculatingStringAverage(string input)
    {
        _actual = StringAverage.AverageString(input);
    }
}