using CV.Application.Models;
using CV.Contracts.Responses.CandidateResponse;
using CV.Contracts.Responses.TechStackResponseDTO;
using CV.Contracts.Responses.WorkExperienceResponseDTO;

namespace CV_backend.Mapping.TechStackMapping
{
    public static class TechStackContractMapping
    {
        public static TechStackResponse MapToTechStackResponse(this TechStack response)
        {
            var TechStackResponse = new TechStackResponse
            {
                TechStackId = response.TechStackId,
                TechStackName = response.TechStackName,
            };

            return TechStackResponse;
        }

   
        public static TechStackResponses MapToTechStackResponses(this IEnumerable<TechStack> techStackList)
        {
            return new TechStackResponses { TechStackList = techStackList.Select(MapToTechStackResponse) };
        }
    }
}
