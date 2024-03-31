using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Models
{
    public class Candidate
    {
        //UserId is used for internal purposes. Id for external.
        public string UserId { get; init; }
        public Guid Id { get; init; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public bool OpenToWork { get; set; }
        public IEnumerable<WorkExperience> WorkExperience { get; set; } = Enumerable.Empty<WorkExperience>();
        public IEnumerable<TechStack> TechStack { get; set; } = Enumerable.Empty<TechStack>();
    }
}
