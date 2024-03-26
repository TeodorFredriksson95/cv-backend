using CV.Application.Models;
using CV.Contracts.Requests;
using CV.Contracts.Responses.CandidateResponse;
using CV.Contracts.Responses.TechStackResponseDTO;
using CV.Contracts.Responses.WorkExperienceResponseDTO;

namespace CV_backend.Mapping.CandidateContractMapping
{
    public static class CandidateContractMapping
    {

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
        public static CandidateResponses MapToCandidatesResponse(this IEnumerable<Candidate> candidates, int page, int pageSize, int totalCount)
        {
            return new CandidateResponses { ResponseList = candidates.Select(MapToCandidateResponse), Page = page, PageSize = pageSize, Total = totalCount };
        }

        public static GetAllCandidatesOptions MapToOptions(this GetAllCandidatesRequest request)
        {
            return new GetAllCandidatesOptions
            {
                Country = request.Country,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                OpenToWork = request.OpenToWork,
                TechStackName = request.TechStackName,
                PageSize = request.PageSize,
                Page = request.Page,
            };
        }
    }
}
