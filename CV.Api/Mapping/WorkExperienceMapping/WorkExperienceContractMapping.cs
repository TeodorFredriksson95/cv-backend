using CV.Application.Models;
using CV.Contracts.Requests;
using CV.Contracts.Responses.TechStackResponseDTO;
using CV.Contracts.Responses.WorkExperienceResponseDTO;
using Microsoft.AspNetCore.Mvc;
using CV_backend.Util;


namespace CV_backend.Mapping.WorkExperienceMapping
{
    public static class WorkExperienceContractMapping
    {
        public static WorkExperienceResponse MapToWorkExperienceResponse(this WorkExperience response)
        {
            var WorkExperience = new WorkExperienceResponse
            {
                Id = response.WorkExperienceId,
                Category = response.Category,
                Company = response.Company,
                Description = response.Description,
                JobTitle = response.JobTitle,
                StartDate = response.StartDate,
                EndDate = response.EndDate,
            };

            return WorkExperience;
        }


        public static WorkExperienceResponses MapToWorkExperiencesResponse(this IEnumerable<WorkExperience> workExperienceList, int page, int pageSize, int totalCount)
        {
            var response = new WorkExperienceResponses {
                Data = workExperienceList.Select(MapToWorkExperienceResponse),
                Page = page,
                PageSize = pageSize,
                Total = totalCount,
            };
            

            return response;
        }

        public static GetAllWorkExperiencesOptions MapToOptions(this GetAllWorkExperiencesRequest request)
        {
            return new GetAllWorkExperiencesOptions
            {
                Category = request.Category,
                Company = request.Company,
                JobTitle = request.JobTitle,
                SortField = request.sortBy?.Trim('+', '-'),
                SortOrder = request.sortBy is null ? SortOrder.Unsorted :
                    request.sortBy.StartsWith('-') ? SortOrder.Descending : SortOrder.Ascending,
                Page = request.Page,
                PageSize = request.PageSize,
            };
        }
    }
}
