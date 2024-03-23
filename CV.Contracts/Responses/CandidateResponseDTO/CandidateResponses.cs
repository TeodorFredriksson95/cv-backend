using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Responses.CandidateResponse
{
    public class CandidateResponses
    {
        public required IEnumerable<CandidateResponse> Candidates { get; init; } = Enumerable.Empty<CandidateResponse>();

    }
}
