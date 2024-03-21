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
    }
}
