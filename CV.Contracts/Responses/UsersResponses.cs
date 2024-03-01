using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Responses
{
    public class UsersResponses
    {
        public required IEnumerable<UserResponse> Users { get; init; } = Enumerable.Empty<UserResponse>();
    }
}
