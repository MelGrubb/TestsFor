using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace TestsFor
{
    /// <summary>
    ///     A lightweight BDD-style base class for tests.
    /// </summary>
    [TestFixture]
    public abstract class Tests
    {
        /// <summary>The auto-mocking container being used by a test class instance.</summary>
        protected AutoMocker Mocker { get; } = new AutoMocker();

        /// <summary>Sets up the context in which the tests will take place. This occurs once per test.</summary>
        [SetUp]
        protected virtual void SetUp()
        {
        }

        /// <summary>Cleans up the context in which the tests took place. This occurs once per test.</summary>
        [TearDown]
        protected virtual void TearDown()
        {
        }

        protected virtual void Given()
        {
        }

        /// <summary>Performs the actions which the test methods will verify. This occurs once per test fixture.</summary>
        protected virtual void When()
        {
        }

        /// <summary>Sets up the context in which the tests will take place. This occurs once per test fixture.</summary>
        /// <remarks>Ordinarily, you should not need to override this method. Override Given and When instead.</remarks>
        [OneTimeSetUp]
        protected virtual void FixtureSetup()
        {
            Given();
            When();
        }

        /// <summary>Cleans up the context in which the tests took place. This occurs once per test fixture.</summary>
        [OneTimeTearDown]
        protected virtual void FixtureTeardown()
        {
        }

        /// <summary>Gets the mock instance of the specified type from the auto-mocking container.</summary>
        /// <typeparam name="T2">The target type of the mock object to return.</typeparam>
        /// <returns>The mock being used for the specified type.</returns>
        protected Mock<T2> GetMockFor<T2>() where T2 : class
        {
            return Mock.Get(Mocker.Get<T2>());
        }
    }

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
