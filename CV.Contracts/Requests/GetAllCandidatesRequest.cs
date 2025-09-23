using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Requests
{
    public class GetAllCandidatesRequest : PagedRequests
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public bool? OpenToWork { get; set; }
        public string? TechStackName { get; set; }
        public string? Country { get; set; }
    }
}
