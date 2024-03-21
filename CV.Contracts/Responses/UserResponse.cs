using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Contracts.Responses
{
    public class UserResponse
    {
        public required Guid Id { get; init; }
        public required string Firstname { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string CountryOfResidency { get; init; }
    }


}
