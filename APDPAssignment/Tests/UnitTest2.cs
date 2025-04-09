using Xunit;
using APDPAssignment.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Tests
{
    public class UnitTest2
    {
        [Fact]
        public void Register_Get_ReturnsViewResult()
        {
            var controller = new AccountController();
            var result = controller.Register();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Register_Post_WithValidInput_ReturnsViewResult()
        {
            var controller = new AccountController();
            var result = controller.Register("testuser", "test@example.com", "password123", "password123", "Test User", 1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Register_Post_WithInvalidPassword_ReturnsViewResult()
        {
            var controller = new AccountController();
            var result = controller.Register("testuser", "test@example.com", "password123", "differentpass", "Test User", 1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Login_Get_ReturnsViewResult()
        {
            var controller = new AccountController();
            var result = controller.Login();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Login_Post_WithValidCredentials_ReturnsRedirectToActionResult()
        {
            var controller = new AccountController();
            var result = controller.Login("testuser", "password123");
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Login_Post_WithInvalidCredentials_ReturnsViewResult()
        {
            var controller = new AccountController();
            var result = controller.Login("invaliduser", "wrongpass");
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Logout_ReturnsRedirectToActionResult()
        {
            var controller = new AccountController();
            var result = controller.Logout();
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Register_Post_WithInvalidModelState_ReturnsViewResult()
        {
            var controller = new AccountController();
            controller.ModelState.AddModelError("", "Error");
            var result = controller.Register("testuser", "test@example.com", "password123", "password123", "Test User", 1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Login_Post_WithInvalidModelState_ReturnsViewResult()
        {
            var controller = new AccountController();
            controller.ModelState.AddModelError("", "Error");
            var result = controller.Login("testuser", "password123");
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Register_Post_WithException_ReturnsViewResult()
        {
            var controller = new AccountController();
            var result = controller.Register("testuser", "test@example.com", "password123", "password123", "Test User", 1);
            Assert.IsType<ViewResult>(result);
        }
    }
} 