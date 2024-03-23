using CV.Contracts.Responses.TechStackResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Responses.WorkExperienceResponseDTO
{
    public class WorkExperienceResponses
    {
        public required IEnumerable<WorkExperienceResponse> WorkExperienceList { get; init; } = Enumerable.Empty<WorkExperienceResponse>();

    }
}
