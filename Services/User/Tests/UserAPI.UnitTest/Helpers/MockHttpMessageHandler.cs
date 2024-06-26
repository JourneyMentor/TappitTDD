﻿using Moq.Protected;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.UnitTest.Helpers
{
    internal static class MockHttpMessageHandler<T>
    {
        internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)
        {
            var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
            };

            mockResponse.Content.Headers.ContentType =
                new MediaTypeWithQualityHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return handlerMock;
        }

        //internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<LoyaltyUser> expectedResponse, string endpoint)
        //{
        //    var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
        //    };

        //    mockResponse.Content.Headers.ContentType =
        //        new MediaTypeWithQualityHeaderValue("application/json");

        //    var handlerMock = new Mock<HttpMessageHandler>();

        //    var httpRequestMessage = new HttpRequestMessage
        //    {
        //        RequestUri = new Uri(endpoint),
        //        Method = HttpMethod.Get,
        //    };

        //    handlerMock
        //        .Protected()
        //        .Setup<Task<HttpResponseMessage>>(
        //            "SendAsync",
        //            httpRequestMessage,
        //            ItExpr.IsAny<CancellationToken>())
        //        .ReturnsAsync(mockResponse);

        //    return handlerMock;
        //}

        internal static Mock<HttpMessageHandler> SetupReturn404()
        {
            var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Empty)
            };

            mockResponse.Content.Headers.ContentType =
                new MediaTypeWithQualityHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return handlerMock;
        }
    }

}
