using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Responses.CandidateResponse
{
    public class CandidateResponse
    {
        public Guid PublicUserId { get; init; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public bool OpenToWork { get; set; }
        public IEnumerable<WorkExperienceResponse> WorkExperience { get; set; } = Enumerable.Empty<WorkExperienceResponse>();
        public IEnumerable<TechStackResponse> TechStack { get; set; } = Enumerable.Empty<TechStackResponse>();
    }
    public class WorkExperienceResponse
    {
        public int WorkExperienceId { get; init; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Category { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class TechStackResponse
    {
        public int TechStackId { get; set; }
        public string TechStackName { get; set; }
    }
}

