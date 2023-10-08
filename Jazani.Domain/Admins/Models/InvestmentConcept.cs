using Jazani.Domain.Cores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Models
{
    public class InvestmentConcept : CoreModel<int>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
