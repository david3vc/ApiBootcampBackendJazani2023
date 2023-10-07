using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.PersonTypes
{
    public class PersonTypeSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
