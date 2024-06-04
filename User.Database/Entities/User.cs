using Microsoft.AspNetCore.Identity;

namespace User.Database.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
