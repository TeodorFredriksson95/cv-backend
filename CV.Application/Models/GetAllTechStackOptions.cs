using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Models
{
    public class GetAllTechStackOptions
    {
        public string? TechName { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
