using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Models
{
    public class Candidate
    {
        public string UserId { get; init; }
        public Guid PublicUserId { get; init; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public bool OpenToWork { get; set; }
        public IEnumerable<WorkExperience> WorkExperience { get; set; } = Enumerable.Empty<WorkExperience>();
        public IEnumerable<TechStack> TechStack { get; set; } = Enumerable.Empty<TechStack>();
    }
}
