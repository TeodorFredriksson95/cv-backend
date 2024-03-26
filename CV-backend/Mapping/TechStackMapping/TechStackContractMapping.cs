using CV.Application.Models;
using CV.Contracts.Requests;
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


        public static TechStackResponses MapToTechStackResponses(this IEnumerable<TechStack> techStackList, int page, int pageSize, int totalCount)
        {
            return new TechStackResponses
            {
                ResponseList = techStackList.Select(MapToTechStackResponse),
                Page = page,
                PageSize = pageSize,
                Total = totalCount
            };
        }


        public static GetAllTechStackOptions MapToOptions(this GetAllTechRequest request)
        {
            return new GetAllTechStackOptions
            {
                TechName = request.TechName,
                Page = request.Page,
                PageSize = request.PageSize,
            };
        }


    }
}
