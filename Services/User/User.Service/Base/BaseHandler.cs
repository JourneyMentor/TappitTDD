using System.Security.Claims;
using User.Service.Interfaces.Redis;
using User.Service.Interfaces.UnitOfWorks;

namespace User.Service.Base
{
    public class BaseHandler
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IRedisService redisService;
        //  public readonly string userId;

        public BaseHandler(IUnitOfWork unitOfWork,IRedisService redisService)
        {
            this.unitOfWork = unitOfWork;
            this.redisService = redisService;
          //  userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
