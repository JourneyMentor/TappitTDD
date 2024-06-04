using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.SharedTypes.Models
{
    public interface IUsersService
    {
        Task<List<LoyaltyUser>?> GetAllUsers();
    }
}
