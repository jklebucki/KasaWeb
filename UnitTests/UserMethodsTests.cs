using Kasa.Core.Domain;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class UserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfUserEmailIsValid()
        {
            var user = new User(3, "admin", "TestName", "", "", "test@email.pl", "pass");
            Assert.Pass();
        }

        [Test]
        public void CheckIfUserEmailIsNotValid()
        {
            try
            {
                var user = new User(3, "admin", "TestName", "", "", "test@email", "pass");
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
            Assert.Fail();
        }
    }
}