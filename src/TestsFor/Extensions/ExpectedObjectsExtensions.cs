using ExpectedObjects;

namespace TestsFor.Extensions
{
    // ReSharper disable once IdentifierTypo
    public static class ExpectedObjectsExtensions
    {
        public static void ShouldMatch(this object actual, object expected)
        {
            ShouldExtensions.ShouldMatch(expected as ExpectedObject ?? expected.ToExpectedObject(), actual);
        }

        public static void ShouldNotMatch(this object actual, object expected)
        {
            ShouldExtensions.ShouldNotMatch(expected as ExpectedObject ?? expected.ToExpectedObject(), actual);
        }
    }
}
