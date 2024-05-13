using LXP.Api.Controllers;
using LXP.Common.ViewModels;
using LXP.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace LXP.Api.Tests
{
    public class EnrollmentN_unit
    {
        [Test]
        public async Task AddEnroll_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            var mockEnrollmentService = new Mock<IEnrollmentService>();
            var controller = new EnrollmentController(mockEnrollmentService.Object);
            controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await controller.Addenroll(new EnrollmentViewModel());

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var okResult = result as OkObjectResult;
            var apiResponse = okResult.Value as APIResponse;
            Assert.AreEqual("Not Created", apiResponse.Message);
        }

        [Test]
        public async Task AddEnroll_EnrollmentSuccessful_ReturnsOk()
        {
            // Arrange
            var mockEnrollmentService = new Mock<IEnrollmentService>();
            mockEnrollmentService.Setup(service => service.Addenroll(It.IsAny<EnrollmentViewModel>())).ReturnsAsync(true);
            var controller = new EnrollmentController(mockEnrollmentService.Object);

            // Act
            var result = await controller.Addenroll(new EnrollmentViewModel());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var apiResponse = okResult.Value as APIResponse;
            Assert.AreEqual("Success", apiResponse.Message); // Assuming CreateSuccessResponse returns "Success"
        }

        [Test]
        public async Task AddEnroll_EnrollmentFailed_ReturnsOkWithFailureMessage()
        {
            // Arrange
            var mockEnrollmentService = new Mock<IEnrollmentService>();
            mockEnrollmentService.Setup(service => service.Addenroll(It.IsAny<EnrollmentViewModel>())).ReturnsAsync(false);
            var controller = new EnrollmentController(mockEnrollmentService.Object);

            // Act
            var result = await controller.Addenroll(new EnrollmentViewModel());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Not Created", okResult.Value); // Assuming CreateFailureResponse returns "Not Created"
            Assert.AreEqual(400, okResult.StatusCode);
        }


    }
}
