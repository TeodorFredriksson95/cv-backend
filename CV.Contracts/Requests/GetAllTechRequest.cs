using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Requests
{
    public class GetAllTechRequest : PagedRequests
    {
        public string? TechName { get; set; }

    }
}
