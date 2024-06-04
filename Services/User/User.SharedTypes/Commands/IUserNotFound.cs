using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.SharedTypes.Commands
{
    public interface IUserNotFound
    {
        string UserId { get; }
        string Message { get; }
    }
}
