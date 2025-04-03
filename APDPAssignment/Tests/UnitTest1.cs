//using Xunit;
//using APDPAssignment.Controllers;
//using Microsoft.AspNetCore.Mvc;

//namespace StudentManagementSystem.Tests
//{
//    public class UnitTest1
//    {
//        [Fact]
//        public void Register_Get_ReturnsView()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Register();
//            // Assert
//            Assert.IsType<ViewResult>(result);
//        }

//        [Fact]
//        public void Register_Get_ReturnsError()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Register();
//            // Assert
//            Assert.IsNotType<BadRequestResult>(result);
//        }

//        [Fact]
//        public void Register_Get_ReturnsNotNull()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Register();
//            // Assert
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public void Register_Get_ReturnsViewResult()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Register();
//            // Assert
//            Assert.IsType<ViewResult>(result);
//        }

//        [Fact]
//        public void Register_Get_ReturnsViewResultWithViewData()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Register();
//            // Assert
//            Assert.IsType<ViewResult>(result);
//        }

//        [Fact]
//        public void Register_Get_ReturnsViewResultWithViewName()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Register();
//            // Assert
//            Assert.IsType<ViewResult>(result);
//        }

//        [Fact]
//        public void Login_Get_ReturnsError()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Login();
//            // Assert
//            Assert.IsNotType<BadRequestResult>(result);
//        }

//        [Fact]
//        public void Login_Get_ReturnsNotNull()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Login();
//            // Assert
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public void Login_Get_ReturnsViewResult()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Login();
//            // Assert
//            Assert.IsType<ViewResult>(result);
//        }

//        [Fact]
//        public void Login_Get_ReturnsViewResultWithViewData()
//        {
//            // Arrange
//            var controller = new AccountController();
//            // Act
//            var result = controller.Login();
//            // Assert
//            Assert.IsType<ViewResult>(result);
//        }
//    }
//}