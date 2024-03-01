using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CV.Application.Models
{
    public partial class User
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string CountryOfResidency { get; set; }
    }
}
 