using CV.Contracts.Responses.WorkExperienceResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Responses
{
    public class PagedResponse<TResponse>
    {
        public required IEnumerable<TResponse> ResponseList { get; init; } = Enumerable.Empty<TResponse>();
        public required int PageSize{ get; set; }
        public required int Page{ get; set; }
        public required int Total{ get; set; }
        public bool HasNextPage => Total > (Page * PageSize);

    }
}
