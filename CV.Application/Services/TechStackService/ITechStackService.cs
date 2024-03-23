using CV.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services.TechStackService
{
    public interface ITechStackService
    {
        Task<IEnumerable<TechStack>> GetTechStackList();
        Task<TechStack> GetTechStackById(int id);
    }
}
