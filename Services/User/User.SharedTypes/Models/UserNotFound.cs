using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.SharedTypes.Commands;

namespace User.SharedTypes.Models
{
    public class UserNotFound : IUserNotFound
    {
        public string UserId { get; set; }
        public string Message { get; set; }
    }
}
