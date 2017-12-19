using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuidantFinancial.WebAPI.Models;

namespace GuidantFinancial.WebAPI.Tests.Models
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void Should_return_true_when_update_user_on_successful()
        {
            var repository = new UserRepository();
            var userUpdate = new User
            {
                Id = 3,
                Point = 4
            };
            var actual = repository.Update(userUpdate);
            Assert.AreEqual(actual, true);
        }

        [TestMethod]
        public void Should_return_false_when_update_user_not_exist()
        {
            var repository = new UserRepository();
            var userUpdate = new User
            {
                Id = 5,
                Point = 4
            };
            var actual = repository.Update(userUpdate);
            Assert.AreEqual(actual, false);
        }

        [TestMethod]
        public void Should_return_correct_number_of_users_after_adding()
        {
            var repository = new UserRepository();
            var user = new User
            {
                Name = "Karl",
                Point = 4
            };
            var countBeforeAdding = repository.GetAll().Count;
            var actual = repository.Add(user);
            var countAfterAdding = repository.GetAll().Count;
            Assert.AreEqual(countBeforeAdding, 3);
            Assert.AreEqual(countAfterAdding, 4);
        }
    }
}
