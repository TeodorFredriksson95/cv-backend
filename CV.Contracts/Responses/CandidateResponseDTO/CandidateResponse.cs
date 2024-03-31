using CV.Contracts.Responses.TechStackResponseDTO;
using CV.Contracts.Responses.WorkExperienceResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Responses.CandidateResponse
{
    public class CandidateResponse
    {
        public Guid Id { get; init; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public bool OpenToWork { get; set; }
        public IEnumerable<WorkExperienceResponse> WorkExperience { get; set; } = Enumerable.Empty<WorkExperienceResponse>();
        public IEnumerable<TechStackResponse> TechStack { get; set; } = Enumerable.Empty<TechStackResponse>();
    }


}

