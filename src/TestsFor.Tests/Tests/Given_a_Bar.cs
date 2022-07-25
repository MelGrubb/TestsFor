using ExpectedObjects;
using NUnit.Framework;
using Shouldly;
using TestsFor.Core.Extensions;
using TestsFor.NUnit;
using TestsFor.UnitTests.Model;

// ReSharper disable InconsistentNaming

namespace TestsFor.UnitTests.Tests
{
    [TestFixture]
    internal class Given_a_Bar : TestsFor<Bar>
    {
        protected override void Given()
        {
            base.Given();

            SUT.Name = "BAR!";

            GetMockFor<IBaz>().Setup(x => x.Name).Returns("BAZ!");
        }

        [Test]
        public void Then_Baz_has_been_mocked()
        {
            SUT.Baz.ShouldNotBeNull();
            SUT.Baz.ShouldBeAssignableTo<IBaz>();
            SUT.Baz.ShouldBeSameAs(GetMockFor<IBaz>().Object);
        }

        [Test]
        public void Then_Baz_Name_should_be_BAZ()
        {
            SUT.Baz!.Name.ShouldBe("BAZ!");
        }

        [Test]
        public void Then_Name_should_be_BAR()
        {
            SUT.Name.ShouldBe("BAR!");
        }

        [Test]
        public void Then_Bar_matches_expected()
        {
            SUT.ShouldMatch(new
            {
                Name = "BAR!",
                Baz = new
                {
                    Name = "BAZ!"
                }
            }.ToExpectedObject());
        }
    }
}