using NUnit.Framework;
using Shouldly;
using TestsFor.UnitTests.Model;

namespace TestsFor.UnitTests.Tests
{
    [TestFixture]
    internal class Given_a_User : TestsFor<User>
    {
        protected override void Given()
        {
            base.Given();

            SUT.FirstName = "Fred";
            SUT.LastName = "Frederson";
        }

        [Test]
        public void Then_Orders_is_a_proxy()
        {
            SUT.Orders.ShouldBeOfType(typeof(List<Order>));
        }

        [Test]
        public void Then_FirstName_equals_Fred()
        {
            SUT.FirstName.ShouldBe("Fred");
        }

        [Test]
        public void Then_LastName_equals_Frederson()
        {
            SUT.LastName.ShouldBe("Frederson");
        }

        [Test]
        public void Then_FullName_should_be_Fred_Frederson()
        {
            SUT.FullName.ShouldBe("Fred Frederson");
        }
    }
}