using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.SharedTypes.Commands
{
    public interface IGetUserDetails
    {
        string UserId { get; }
    }
}
