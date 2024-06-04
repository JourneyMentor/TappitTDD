namespace User.Service.Interfaces.Redis
{
    public interface IRedisService
    {
        Task SetValueAsync(string key, string value);
        Task<string> GetValueAsync(string key);
    }
}
