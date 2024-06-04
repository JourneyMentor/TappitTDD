using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.SharedTypes.Models
{
    public static class UsersFixture
    {
        public static List<LoyaltyUser> GetTestUsers() =>
        [
            new LoyaltyUser
            {
                Username = "Test User 1",
                Id = 1
            },
            new LoyaltyUser
            {
                Username = "Test User 2",
                Id = 2
            }
        ];
    }
}