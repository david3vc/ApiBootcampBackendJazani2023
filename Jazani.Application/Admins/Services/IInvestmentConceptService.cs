using Jazani.Application.Admins.Dtos.InvestmentConcepts;
using Jazani.Application.Cores.Services;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Services
{
    public interface IInvestmentConceptService : ICrudService<InvestmentConceptDto, InvestmentConceptSaveDto, int>
    {
    }
}
