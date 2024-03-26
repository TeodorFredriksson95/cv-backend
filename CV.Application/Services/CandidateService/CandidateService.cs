using CV.Application.Models;
using CV.Application.Repositories.CandidateRepository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services.CandidateService
{

    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IValidator<GetAllCandidatesOptions> _optionsValidator;
        public CandidateService(ICandidateRepository candidateRepository, IValidator<GetAllCandidatesOptions> optionsValidator)
        {

            _candidateRepository = candidateRepository;
            _optionsValidator = optionsValidator;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesFullProfile(GetAllCandidatesOptions options, CancellationToken cancellationToken = default)
        {
            await _optionsValidator.ValidateAndThrowAsync(options);
            return await _candidateRepository.GetAllCandidatesFullProfile(options, cancellationToken);
        }

        public async Task<Candidate> GetCandidateByIdAsync(Guid publicUserId)
        {
            return await _candidateRepository.GetCandidateByPublicIdAsync(publicUserId);
            
        }

        public async Task<int> GetCandidatesCountFullProfileAsync(GetAllCandidatesOptions options, CancellationToken cancellationToken = default)
        {
            return await _candidateRepository.GetAllCandidatesCountFullProfileAsync(options, cancellationToken);
        }

     
    }
}
