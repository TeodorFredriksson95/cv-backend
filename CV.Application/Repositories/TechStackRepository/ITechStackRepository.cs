using CV.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Repositories.TechStackRepository
{
    public interface ITechStackRepository
    {
        Task<IEnumerable<TechStack>> GetTechStackList(GetAllTechStackOptions options);
        Task<TechStack> GetTechStackById(int techId);
        Task<int> GetTechStackCountAsync(string? techName);

    }
}
