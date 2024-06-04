using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.SharedTypes.Commands
{
    public interface IUserDetailsReceived
    {
        string UserId { get; }
        string Name { get; }
        string Email { get; }
    }
}
