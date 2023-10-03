using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Dtos.Nationalities
{
    public class NationalitySaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
