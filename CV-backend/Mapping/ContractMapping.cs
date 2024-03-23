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

    

    }
}
