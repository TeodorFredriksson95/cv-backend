using CV.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Repositories.CandidateRepository
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetCandidate(CancellationToken token = default);
        Task<Candidate> GetCandidateByPublicIdAsync(Guid publicUserId);
        Task<IEnumerable<Candidate>> GetAllCandidatesFullProfile(GetAllCandidatesOptions options, CancellationToken cancellationToken = default);
        Task<int> GetAllCandidatesCountFullProfileAsync(GetAllCandidatesOptions options, CancellationToken cancellationToken = default);
    }
}
