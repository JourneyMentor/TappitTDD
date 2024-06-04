using MassTransit;
using User.SharedTypes.Commands;
using User.Service.Interfaces.Redis;
using User.Service.Base;
using User.Service.Interfaces.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using User.SharedTypes.Models;

namespace User.Service.Consumer
{
    public class GetUserDetailsConsumer : BaseHandler, IConsumer<IGetUserDetails>
    {

        public GetUserDetailsConsumer(IRedisService redisService, IUnitOfWork unitOfWork) : base(unitOfWork, redisService)
        {
        }

        public async Task Consume(ConsumeContext<IGetUserDetails> context)
        {
            var cacheKey = "";
            var message = context.Message;
            var users = await unitOfWork.GetReadRepository<Database.Entities.User>().GetAllAsync();
            var user = users.FirstOrDefault();

            var cachedUser = await redisService.GetValueAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedUser))
            {
                var userDetails = JsonSerializer.Deserialize<UserDetailsReceived>(cachedUser);
                await context.RespondAsync<IUserDetailsReceived>(userDetails);
                return;
            }
            await redisService.SetValueAsync(cacheKey, JsonSerializer.Serialize(user));

            #region
            //await context.RespondAsync<IUserDetailsReceived>(new
            //{
            //    UserId = user.Id,
            //    Name = user.UserName,
            //    Email = user.Email
            //});
            #endregion

        }
    }
}
