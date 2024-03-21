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
        Task<IEnumerable<Candidate>> GetFullCandidateProfile(CancellationToken token = default);
        Task<Candidate> GetCandidateByIdAsync(Guid publicUserId);

    }
}
