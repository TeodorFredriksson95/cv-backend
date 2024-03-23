using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Responses.WorkExperienceResponseDTO
{
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
}
