namespace ContainsDuplicateII;

public class ContainsDuplicate2Test
{
    private bool _actual;

    [TestCase(new int[] { 1, 2, 3, 1 }, 3, true)]
    [TestCase(new int[] { 1, 0, 1, 1 }, 1, true)]
    [TestCase(new int[] { 1, 2, 3, 1, 2, 3 }, 2, false)]
    public void given_array_of_element_when_checking_contain_duplicate_then_should_return_expected(int[] input, int k, bool expected)
    {
        WhenCheckingContainsDuplicate(input, k);
        ResultShouldBe(expected);
    }

    private void ResultShouldBe(bool expected)
    {
        Assert.That(_actual, Is.EqualTo(expected));
    }

    private void WhenCheckingContainsDuplicate(int[] input, int k)
    {
        _actual = ContainsDuplicate2.ContainsNearbyDuplicate(input, k);
    }
}