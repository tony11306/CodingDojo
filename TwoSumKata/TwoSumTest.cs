namespace TwoSumKata;

public class TwoSumTest
{
    private int[] _actual;
    private int[] _input;
    private int _target;

    [SetUp]
    public void SetUp()
    {
        _actual = [];
        _input = [];
    }

    [Test]
    public void given_all_positive_input_when_getting_two_sum_then_should_return_answer()
    {
        GivenInput([2,7,11,15], 9);
        var expected = new[] { 0, 1 };

        WhenGettingTwoSum(_input, _target);
        
        AnswerShouldBe(expected);
    }

    [Test]
    public void given_all_negative_input_when_getting_two_sum_then_should_return_answer()
    {
        GivenInput([-4, -7, -5, -1, -3], -6);

        WhenGettingTwoSum(_input, _target);
        
        AnswerShouldBe([2, 3]);
    }

    [Test]
    public void given_integer_input_when_getting_two_sum_then_should_return_answer()
    {
        GivenInput([3, 2, 7, -14, 8, 9], -12);

        WhenGettingTwoSum(_input, _target);
        
        AnswerShouldBe([3, 1]);
    }

    private void GivenInput(int[] input, int target)
    {
        _input = input;
        _target = target;
    }

    private void AnswerShouldBe(int[] expected)
    {
        expected = expected.OrderBy(x => x).ToArray();
        _actual = _actual.OrderBy(x => x).ToArray();
        
        Assert.That(_actual, Is.EqualTo(expected));
    }

    private void WhenGettingTwoSum(int[] input, int target)
    {
        _actual = TwoSum.GetTwoSum(input, target);
    }
}