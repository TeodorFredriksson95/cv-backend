using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Models
{
    public class GetAllCandidatesOptions
    {

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public bool? OpenToWork { get; set; }
        public string? TechStackName { get; set; }
        public string? Country { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
