using MassTransit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Service.Consumer;
using User.SharedTypes.Commands;
using Xunit;

namespace UserService.UnitTest.Systems.Controllers
{
    public class GetUserDetailsConsumerTest
    {
        //[Fact]
        //public async Task Consume_ValidRequest_ReturnsUserDetails()
        //{
        //    try
        //    {
        //        var userId = Guid.NewGuid();
        //        var consumeContextMock = new Mock<ConsumeContext<IGetUserDetails>>();
        //        consumeContextMock.Setup(x => x.Message).Returns(new TestGetUserDetails { UserId = userId });

        //        var consumer = new GetUserDetailsConsumer();

        //        // Act
        //        await consumer.Consume(consumeContextMock.Object);

        //        // Assert
        //        consumeContextMock.Verify(m => m.RespondAsync(
        //            It.Is<IUserDetailsReceived>(user => user.UserId == userId && user.Name == "Example User" && user.Email == "example@user.com"),
        //            default), Times.Once);
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }

    public class TestGetUserDetails : IGetUserDetails
    {
        public Guid UserId { get; set; }

        string IGetUserDetails.UserId => throw new NotImplementedException();
    }
}