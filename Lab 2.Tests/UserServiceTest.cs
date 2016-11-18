using NUnit.Framework;
using Lab_2.Services;
using Lab_2.Models;

namespace Lab_2.Tests
{
    [TestFixture]
    public class UserServiceTest
    {
        private IUserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userService = new UserService();
        }

        [Test]
        public void WhenNoSiblingsThenOnlyChild()
        {
            var user = new User
            {
                FirstName = "Mary",
                LastName = "Sue",
                EmailAddress = "marysue@email.com",
                NumberOfSiblings = "0"
            };

            var result = _userService.UserIsOnlyChild(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void WhenSiblingsThenNotOnlyChild()
        {
            var user = new User
            {
                FirstName = "Mary",
                LastName = "Sue",
                EmailAddress = "marysue@email.com",
                NumberOfSiblings = "5"
            };

            var result = _userService.UserIsOnlyChild(user);

            Assert.IsFalse(result);
        }
    }
}
