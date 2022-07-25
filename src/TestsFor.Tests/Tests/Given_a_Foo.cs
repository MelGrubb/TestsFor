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
    internal class Given_a_Foo : TestsFor<Foo>
    {
        protected override void Given()
        {
            base.Given();

            SUT.Name = "FOO!";

            var mockBaz = GetMockFor<IBaz>();
            mockBaz.Setup(x => x.Name).Returns("BAZ!");

            var mockIBar = GetMockFor<IBar>();
            mockIBar.Setup(x => x.Name).Returns("BAR!");
            mockIBar.Setup(x => x.Baz).Returns(mockBaz.Object);
        }

        [Test]
        public void Then_Bar_has_been_mocked()
        {
            SUT.Bar.ShouldNotBeNull();
            SUT.Bar.ShouldBeAssignableTo<IBar>();
            SUT.Bar.ShouldBeSameAs(GetMockFor<IBar>().Object);
        }

        [Test]
        public void Then_Bar_Name_should_be_BAR()
        {
            SUT.Bar.Name.ShouldBe("BAR!");
        }

        [Test]
        public void Then_Baz_Name_should_be_BAZ()
        {
            SUT.Bar.Baz!.Name.ShouldBe("BAZ!");
        }

        [Test]
        public void Then_Foo_matches_expected()
        {
            SUT.ShouldMatch(new
            {
                Name = "FOO!",
                Bar = new
                {
                    Name = "BAR!",
                    Baz = new
                    {
                        Name = "BAZ!"
                    }
                }
            }.ToExpectedObject());
        }

        [Test]
        public void Then_Foo_is_equal_to_expected()
        {
            var expected = new Foo(new Bar(new Baz { Name = "BAZ!" }) { Name = "BAR!" }) { Name = "FOO!" };
            SUT.ShouldMatch(expected);

            SUT.Bar.Baz = null;
            SUT.ShouldMatch(expected);

            //SUT.Bar = new Bar(new Baz());
            //SUT.ShouldMatch(expected);
        }
    }
}