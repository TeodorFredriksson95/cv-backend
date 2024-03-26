using CV.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services.CandidateService
{
    public interface ICandidateService
    {
        Task<Candidate> GetCandidateByIdAsync(Guid publicUserId);
        Task<IEnumerable<Candidate>> GetAllCandidatesFullProfile(GetAllCandidatesOptions options, CancellationToken cancellationToken = default);
        Task<int> GetCandidatesCountFullProfileAsync(GetAllCandidatesOptions options, CancellationToken cancellationToken = default);

    }
}
