using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.SharedTypes.Commands;

namespace User.SharedTypes.Models
{
    public class UserDetailsReceived : IUserDetailsReceived
    {

        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
