using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using User.SharedTypes.Commands;
using User.SharedTypes.Models;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRequestClient<IGetUserDetails> _requestClient;

        public UserController(IRequestClient<IGetUserDetails> requestClient)
        {
            _requestClient = requestClient ?? throw new ArgumentNullException(nameof(requestClient));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            try
            {
                var userId = Guid.Parse("11111111-1111-1111-1111-111111111111");

                var (response, notFound) = await _requestClient.GetResponse<IUserDetailsReceived, IUserNotFound>(new
                {
                    UserId = userId
                });

                //if (notFound.IsCompletedSuccessfully)
                //{
                //    return NotFound(new { Message = "User not found.", UserId = userId });
                //}

                var userDetails = await response;
                return Ok(new UserDetailsReceived
                {
                    UserId = userDetails.Message.UserId,
                    Name = userDetails.Message.Name,
                    Email = userDetails.Message.Email
                });
            }
            catch (RequestTimeoutException ex)
            {
                return StatusCode(504, new { Message = "Request timed out.", Details = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Details = ex.Message });
            }
        }
    }
}
