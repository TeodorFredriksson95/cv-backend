using CV.Application.Services.CandidateService;
using CV.Application.Services.TechStackService;
using CV.Application.Services;
using CV.Contracts.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CV_backend.Mapping.TechStackMapping;

namespace CV_backend.Controllers
{
    [Authorize]
    [ApiController]
    public class TechStackController : Controller
    {
        private readonly ITechStackService _techStackService;
        private readonly ILinkService _linkService;
        public TechStackController(ICandidateService candidateService, ITechStackService techStackService, ILinkService linkService)
        {
            _techStackService = techStackService;
            _linkService = linkService;
        }

        [HttpGet(ApiEndpoints.V1.TechStackEndpoints.GetAllTech, Name = "GetAllTech")]
        public async Task<IActionResult> GetAllTech([FromQuery] GetAllTechRequest request, CancellationToken token)
        {
            var options = request.MapToOptions();
            var allTech = await _techStackService.GetTechStackList(options);

            var techListCount = await _techStackService.GetTechStackCountAsync(options.TechName);

            if (allTech == null)
            {
                return NotFound();
            }

            var response = allTech.MapToTechStackResponses(request.Page, request.PageSize, techListCount);
            response.Links = _linkService.GenerateLinks("GetAllTech", Url, request.Page, request.PageSize, techListCount);

            return Ok(response);
        }

        [HttpGet(ApiEndpoints.V1.TechStackEndpoints.GetTechById)]
        public async Task<IActionResult> GetTechById([FromRoute] int id, CancellationToken token)
        {
            var techById = await _techStackService.GetTechStackById(id);
            if (techById == null)
            {
                return NotFound();
            }
            return Ok(techById.MapToTechStackResponse());
        }

    }
}
