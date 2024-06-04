using Microsoft.Extensions.Options;
using Moq.Protected;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.UnitTest.Helpers;
using Xunit;
using User.SharedTypes.Models;

namespace UserService.UnitTest.Systems.Services
{
    public class TestUserServiceService
    {
        //[Fact]
        //public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        //{
        //    // Arrange
        //    var handlerMock = MockHttpMessageHandler<LoyaltyUser>.SetupBasicGetResourceList(UsersFixture.GetTestUsers());
        //    var config = Options.Create(new UsersApiOptions
        //    {
        //        Endpoint = "https://jsonplaceholder.typicode.com/users"
        //    });
        //    var usersService = new UserService(new HttpClient(handlerMock.Object), config);

        //    // Act
        //    await usersService.GetAllUsers();

        //    //Assert
        //    handlerMock
        //        .Protected()
        //        .Verify(
        //            "SendAsync",
        //            Times.Exactly(1),
        //            ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
        //            ItExpr.IsAny<CancellationToken>()
        //        );
        //}

        //[Fact]
        //public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
        //{
        //    // Arrange
        //    var handlerMock = MockHttpMessageHandler<LoyaltyUser>.SetupReturn404();
        //    var config = Options.Create(new UsersApiOptions
        //    {
        //        Endpoint = "https://jsonplaceholder.typicode.com/users"
        //    });
        //    var usersService = new UsersService(new HttpClient(handlerMock.Object), config);

        //    // Act
        //    var result = await usersService.GetAllUsers();

        //    //Assert
        //    result?.Count.Should().Be(0);
        //}

        //[Fact]
        //public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpectedSize()
        //{
        //    // Arrange
        //    var expectedResponse = UsersFixture.GetTestUsers();
        //    var config = Options.Create(new UsersApiOptions
        //    {
        //        Endpoint = "https://jsonplaceholder.typicode.com/users"
        //    });

        //    var handlerMock = MockHttpMessageHandler<LoyaltyUser>.SetupBasicGetResourceList(expectedResponse);

        //    var usersService = new UsersService(new HttpClient(handlerMock.Object), config);

        //    // Act
        //    var result = await usersService.GetAllUsers();

        //    //Assert
        //    result?.Count.Should().Be(expectedResponse.Count);
        //}


        //[Fact]
        //public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
        //{
        //    // Arrange
        //    var expectedResponse = UsersFixture.GetTestUsers();

        //    var config = Options.Create(new UsersApiOptions
        //    {
        //        Endpoint = "https://jsonplaceholder.typicode.com/users"
        //    });

        //    var handlerMock = MockHttpMessageHandler<LoyaltyUser>.SetupBasicGetResourceList(expectedResponse, config.Value.Endpoint);

        //    var usersService = new UsersService(new HttpClient(handlerMock.Object), config);

        //    // Act
        //    var result = await usersService.GetAllUsers();

        //    //Assert

        //    handlerMock
        //        .Protected()
        //        .Verify(
        //            "SendAsync",
        //            Times.Exactly(1),
        //            ItExpr.Is<HttpRequestMessage>(
        //                req => req.Method == HttpMethod.Get &&
        //                       req.RequestUri.ToString() == new Uri(config.Value.Endpoint).ToString()),
        //            ItExpr.IsAny<CancellationToken>()
        //        );
        //}
    }
}
