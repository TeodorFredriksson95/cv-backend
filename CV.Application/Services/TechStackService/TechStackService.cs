using CV.Application.Models;
using CV.Application.Repositories.TechStackRepository;
using FluentValidation;
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
        private readonly IValidator<GetAllTechStackOptions> _optionsValidator;

        public TechStackService(ITechStackRepository techStackRepository, IValidator<GetAllTechStackOptions> optionsValidator)
        {
            _techStackRepository = techStackRepository;
            _optionsValidator = optionsValidator;
        }

        public async Task<TechStack> GetTechStackById(int id)
        {
            return await _techStackRepository.GetTechStackById(id);
        }

        public async Task<int> GetTechStackCountAsync(string? techName)
        {
            return await _techStackRepository.GetTechStackCountAsync(techName);
        }

        public async Task<IEnumerable<TechStack>> GetTechStackList(GetAllTechStackOptions options)
        {
            await _optionsValidator.ValidateAndThrowAsync(options);
            return await _techStackRepository.GetTechStackList(options);
        }
    }
}
