namespace TestsFor
{
    /// <summary>
    ///     A lightweight BDD-style base class for tests for a given type.
    /// </summary>
    /// <typeparam name="T">The type of the SUT (System under test) property.</typeparam>
    public abstract class TestsFor<T> : Tests where T : class
    {
        // ReSharper disable once InconsistentNaming
        /// <summary>The system-under-test.</summary>
        protected T SUT { get; set; } = null!;

        /// <summary>Sets up the context in which the tests will take place. This occurs once per test fixture.</summary>
        /// <remarks>
        ///     If you need to inject items into the auto-mocking container, override this method, perform your setup, and then
        ///     call the base implementation.
        ///     If you want complete control over the construction of SUT, then override this method and do not call the base
        ///     implementation.
        /// </remarks>
        protected override void Given()
        {
            SUT = Mocker.CreateInstance<T>();
        }
    }
}
