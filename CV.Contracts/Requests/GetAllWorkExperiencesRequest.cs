using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Requests
{
    public class GetAllWorkExperiencesRequest : PagedRequests 
    {
        public string? Company { get; init; }
        public string? Category { get; init; }
        public string? JobTitle { get; init; }
        public string? sortBy { get; init; }
    }
}
