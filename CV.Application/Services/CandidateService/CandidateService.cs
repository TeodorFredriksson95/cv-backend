using CV.Application.Models;
using CV.Application.Repositories.CandidateRepository;
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
        public CandidateService(ICandidateRepository candidateRepository)
        {

            _candidateRepository = candidateRepository;

        }

        public async Task<Candidate> GetCandidateByIdAsync(Guid publicUserId)
        {
            return await _candidateRepository.GetCandidateByPublicIdAsync(publicUserId);
            
        }

        public Task<IEnumerable<Candidate>> GetFullCandidateProfile(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
