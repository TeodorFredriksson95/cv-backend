using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Responses.TechStackResponseDTO
{
    public class TechStackResponses
    {
        public required IEnumerable<TechStackResponse> TechStackList { get; init; } = Enumerable.Empty<TechStackResponse>();

    }
}
