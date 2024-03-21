using CV.Application.Models;
using CV.Contracts.Responses;
using CV.Contracts.Responses.CandidateResponse;
using Microsoft.AspNetCore.Mvc;

namespace CV_backend.Mapping
{
    public static class ContractMapping
    {
        public static UserResponse MapToUserResponse(this User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                CountryOfResidency = user.CountryOfResidency,
                Email = user.Email,
                Firstname = user.FirstName,
                LastName = user.LastName
            };
        }

        public static UsersResponses MapToUsersResponse(this IEnumerable<User> users)
        {
            return new UsersResponses
            {
                Users = users.Select(MapToUserResponse)
            };
        }

        public static CandidateResponse MapToCandidateResponse(this Candidate candidate)
        {
            var candidateResponse = new CandidateResponse
            {
                Country = candidate.Country,
                Email = candidate.Email,
                Firstname = candidate.Firstname,
                Lastname = candidate.Lastname,
                OpenToWork = candidate.OpenToWork,
                PublicUserId = candidate.PublicUserId,
                WorkExperience = candidate.WorkExperience.Select(we => new WorkExperienceResponse
                {
                    WorkExperienceId = we.WorkExperienceId,
                    Category = we.Category,
                    StartDate = we.StartDate,
                    EndDate = we.EndDate,
                    Company = we.Company,
                    Description = we.Description,
                    JobTitle = we.JobTitle,
                }),
                TechStack = candidate.TechStack.Select(ts => new TechStackResponse
                {
                    TechStackId = ts.TechStackId,
                    TechStackName = ts.TechStackName,
                })
            };
            return candidateResponse;
        }
    }
}
