using CV.Application.Models;
using CV.Contracts.Responses.TechStackResponseDTO;
using CV.Contracts.Responses.WorkExperienceResponseDTO;

namespace CV_backend.Mapping.WorkExperienceMapping
{
    public static class WorkExperienceContractMapping
    {
        public static WorkExperienceResponse MapToWorkExperienceResponse(this WorkExperience response)
        {
            var WorkExperience = new WorkExperienceResponse
            {
                WorkExperienceId = response.WorkExperienceId,
                Category = response.Category,
                Company = response.Company,
                Description = response.Description,
                JobTitle = response.JobTitle,
                StartDate = response.StartDate,
                EndDate = response.EndDate,
            };

            return WorkExperience;
        }


        public static WorkExperienceResponses MapToCandidatesResponse(this IEnumerable<WorkExperience> workExperienceList)
        {
            return new WorkExperienceResponses { WorkExperienceList = workExperienceList.Select(MapToWorkExperienceResponse) };
        }
    }
}
