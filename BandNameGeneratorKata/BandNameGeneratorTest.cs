namespace BandNameGenerator;

[TestFixture]
[TestOf(typeof(BandNameGenerator))]
public class BandNameGeneratorTest
{
    private string _actual;

    [SetUp]
    public void SetUp()
    {
        _actual = string.Empty;
    }

    [TestCase("knife", "The Knife")]
    [TestCase("bed", "The Bed")]
    public void given_diff_first_and_last_letter_noun_when_generate_band_name_then_should_return_The_Noun_format(string input, string expected)
    {
        WhenGenerateBandName(input);
        Assert.That(_actual, Is.EqualTo(expected));
    }

    [TestCase("tart", "Tartart")]
    [TestCase("sandles", "Sandlesandles")]
    public void given_same_first_and_last_letter_noun_when_generate_band_name_then_should_return_capitalized_repeated_format(string input, string expected)
    {
        WhenGenerateBandName(input);
        Assert.That(_actual, Is.EqualTo(expected));
    }

    private void WhenGenerateBandName(string input)
    {
        _actual = BandNameGenerator.GenerateBandName(input);
    }
}