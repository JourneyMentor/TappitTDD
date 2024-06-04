using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.SharedTypes.Models;

namespace UserAPI.UnitTest.Fixtures
{
    public class UsersAPIFixture
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
