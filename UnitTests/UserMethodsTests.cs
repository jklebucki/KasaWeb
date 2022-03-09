using Kasa.Core.Domain;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfUserEmailIsValid()
        {
            var companyIds = new int[] { 1, 2, 3 };
            var roles = new string[] { "admin", "user" };
            var user = new User(3, "admin", "TestName", "test@email.pl", "pass", roles, companyIds);
            Assert.Pass();
        }
    }
}