using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using User.API.Controllers;
using User.SharedTypes.Commands;
using User.SharedTypes.Models;
using Xunit;

namespace UserAPI.UnitTest.Systems.Controllers
{
    public class UserControllerTests
    { 
        [Fact]
        public async Task GetUserDetails_ValidRequest_ReturnsOkObjectResult()
        {
            try
            {
                // Arrange
                var userId = "11111111-1111-1111-1111-111111111111";
                var mockRequestClient = new Mock<IRequestClient<IGetUserDetails>>();
                var mockResponse = new Mock<Response<IUserDetailsReceived>>();
                var responseContext = new Mock<ConsumeContext<IUserDetailsReceived>>();

                responseContext.Setup(x => x.Message).Returns(new UserDetailsReceived
                {
                    UserId = userId,
                    Name = "Example User",
                    Email = "example@user.com"
                });

                mockResponse.Setup(x => x.Message).Returns(responseContext.Object.Message);

                var responseTask = Task.FromResult(mockResponse.Object);
                var notFoundTask = Task.FromResult<Response<IUserNotFound>>(null);

                mockRequestClient.Setup(x => x.GetResponse<IUserDetailsReceived, IUserNotFound>(It.IsAny<object>(), It.IsAny<CancellationToken>(), It.IsAny<RequestTimeout>()))
                                 .ReturnsAsync((responseTask, notFoundTask));

                var controller = new UserController(mockRequestClient.Object);

                // Act
                var result = await controller.GetUserDetails();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);

                // Instead of checking the type, compare properties directly
                var returnValue = okResult.Value as UserDetailsReceived;
                Assert.NotNull(returnValue);

                Assert.Equal(userId, returnValue.UserId);
                Assert.Equal("Example User", returnValue.Name);
                Assert.Equal("example@user.com", returnValue.Email);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [Fact]
        public async Task GetUserDetails_UserNotFound_ReturnsNotFoundResult()
        {
            try
            {
                var userId = "11111111-1111-1111-1111-111111111111";
                var mockRequestClient = new Mock<IRequestClient<IGetUserDetails>>();
                var mockNotFoundResponse = new Mock<Response<IUserNotFound>>();

                mockNotFoundResponse.Setup(x => x.Message).Returns(new UserNotFound
                {
                    UserId = userId,
                    Message = "User not found."
                });

                mockRequestClient.Setup(x => x.GetResponse<IUserDetailsReceived, IUserNotFound>(It.IsAny<object>(), It.IsAny<CancellationToken>(), It.IsAny<RequestTimeout>()))
                                 .ReturnsAsync((Task.FromResult<Response<IUserDetailsReceived>>(null), Task.FromResult(mockNotFoundResponse.Object)));

                var controller = new UserController(mockRequestClient.Object);

                // Act
                var result = await controller.GetUserDetails();

                // Assert
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                var returnValue = Assert.IsType<UserNotFound>(notFoundResult.Value);

                Assert.Equal(userId, returnValue.UserId);
                Assert.Equal("User not found.", returnValue.Message);
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
