using CV.Application.Models;
using CV.Application.Repositories.TechStackRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services.TechStackService
{
    public class TechStackService : ITechStackService
    {
        private readonly ITechStackRepository _techStackRepository;

        public TechStackService(ITechStackRepository techStackRepository)
        {
            _techStackRepository = techStackRepository;
        }

        public async Task<TechStack> GetTechStackById(int id)
        {
            return await _techStackRepository.GetTechStackById(id);
        }

        public async Task<IEnumerable<TechStack>> GetTechStackList()
        {
            return await _techStackRepository.GetTechStackList();
        }
    }
}
