using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Requests
{
    public class PagedRequests
    {
        public required int Page { get; set; } = 1;
        public required int PageSize { get; set; } = 10;
    }
}
