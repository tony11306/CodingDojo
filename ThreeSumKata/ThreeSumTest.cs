namespace ThreeSumKata;

public class ThreeSumTest
{
    private IList<IList<int>> _actual;
    private int[] _input;
    private ThreeSum _threeSum;

    [SetUp]
    public void SetUp()
    {
        _threeSum = new ThreeSum();
    }

    [Test]
    public void given_empty_list_when_finding_three_sum_then_should_return_empty_list()
    {
        GivenInput([]);
        var expected = new List<IList<int>>();

        WhenGettingThreeSum();

        ResultShouldBe(expected);
    }

    [Test]
    public void given_less_then_3_elements_when_finding_three_sum_then_should_return_empty_list()
    {
        GivenInput([0, 0]);
        var expected = new List<IList<int>>();

        WhenGettingThreeSum();

        ResultShouldBe(expected);
    }

    [Test]
    public void given_no_answer_list_when_finding_three_sum_then_should_return_empty_list()
    {
        GivenInput([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        var expected = new List<IList<int>>();

        WhenGettingThreeSum();

        ResultShouldBe(expected);
    }

    [Test]
    public void given_6_zero_list_when_finding_three_sum_then_should_return_one_answer()
    {
        GivenInput([0, 0, 0, 0, 0, 0]);
        var expected = new List<IList<int>> { new List<int> { 0, 0, 0 } };

        WhenGettingThreeSum();

        ResultShouldBe(expected);
    }

    [Test]
    public void given_no_duplicate_answer_list_when_finding_three_sum_then_should_return_answer()
    {
        GivenInput([-1, 0, 1, 2, -1, -4]);
        var expected = new List<IList<int>> { new List<int> { -1, -1, 2 }, new List<int> { -1, 0, 1 } };

        WhenGettingThreeSum();

        ResultShouldBe(expected);
    }

    [Test]
    public void given_contained_duplicate_answer_list_when_finding_three_sum_then_should_filter_out_duplicates()
    {
        GivenInput([-1, 0, 1, 2, -1, -4, -1]);
        var expected = new List<IList<int>> { new List<int> { -1, -1, 2 }, new List<int> { -1, 0, 1 } };

        WhenGettingThreeSum();

        ResultShouldBe(expected);
    }

    private void WhenGettingThreeSum()
    {
        _actual = _threeSum.GetThreeSum(_input);
    }

    private void ResultShouldBe(List<IList<int>> expected)
    {
        var sortedExpected = expected.Select(
                list => list.OrderBy(x => x)
                    .ToList()
            )
            .OrderBy(list => list[0])
            .ToList();

        var sortedActual = _actual.Select(
                list => list.OrderBy(x => x)
                    .ToList()
            )
            .OrderBy(list => list[0])
            .ToList();

        Assert.That(sortedActual, Is.EqualTo(sortedExpected));
    }

    private void GivenInput(int[] input)
    {
        _input = input;
    }
}