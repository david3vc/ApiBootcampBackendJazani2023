using Jazani.Core.Securities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.Users
{
    public class UserSecurityDto : UserDto
    {
        public SecurityEntity Security {  get; set; }
    }
}
