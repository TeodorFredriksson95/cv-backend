using CV.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Validators.CandidateValidators
{
    public class GetCandidatesOptions : AbstractValidator<GetAllCandidatesOptions>
    {
        public GetCandidatesOptions()
        {
            RuleFor(x => x.Page)
              .GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 10)
                .WithMessage("You can get between 1 and 10 items per page");
        }
    }
}
