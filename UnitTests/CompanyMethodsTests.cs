using Kasa.Core.Domain;
using NUnit.Framework;

namespace UnitTests
{
    public class CompanyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfCompanyEmailIsValid()
        {
            Company company = new(0, "TestName", "TestDesc", "Test street", "Zgorzelec", "59-900", "", "Poland", "email@citronex.pl", "");
            Assert.Pass();
        }
    }
}