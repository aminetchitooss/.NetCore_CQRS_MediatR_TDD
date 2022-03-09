using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDD_Sample_dotNet.Controllers;
using TDD_Sample_dotNet.Models;
using TDD_Sample_dotNet.Services;
using Xunit;

namespace TDD_Sample_dotNet.Tests
{
    public class UserServiceTests : ControllerBase
    {
        private readonly UserController _testedController;
        private readonly Mock<IUserService> _repoMoq = new Mock<IUserService>();


        public UserServiceTests()
        {
            _testedController = new UserController(_repoMoq.Object);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnUser_WhenUserExits()
        {

            int UserId = It.IsAny<int>();

            var expected = new User("testcase", 20);

            _repoMoq.Setup(x => x.GetUserById(UserId)).ReturnsAsync(expected);

            var result = await _testedController.GetUser(UserId);

            Assert.NotStrictEqual(expected, result);
        }


        [Fact]
        public async Task GetUserById_ShouldReturnNotFound_WhenUserDoesNotExist()
        {

            int UserId = It.IsAny<int>();

            var expected = NotFound();

            _repoMoq.Setup(x => x.GetUserById(UserId)).ReturnsAsync(expected);

            var result = await _testedController.GetUser(UserId);

            Assert.NotStrictEqual(expected, result);
        }
    }
}
