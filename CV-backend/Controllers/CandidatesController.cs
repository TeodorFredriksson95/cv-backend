using CV.Api;
using CV.Application.Models;
using CV.Application.Services;
using CV.Application.Services.ApiKeyService;
using CV.Application.Services.CandidateService;
using CV.Application.Services.TechStackService;
using CV.Application.Services.WorkExperienceService;
using CV.Contracts.Requests;
using CV_backend.Mapping.CandidateContractMapping;
using CV_backend.Mapping.TechStackMapping;
using CV_backend.Mapping.WorkExperienceMapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace CV_backend.Controllers
{
    [Authorize]
    [ApiController]
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly ITechStackService _techStackService;
        private readonly ILinkService _linkService;
        public CandidatesController(ICandidateService candidateService, ITechStackService techStackService, ILinkService linkService)
        {
            _candidateService = candidateService;
            _techStackService = techStackService;
            _linkService = linkService;
        }


        [HttpGet(ApiEndpoints.V1.CandidateEndpoints.GetCandidateById)]
        public async Task<IActionResult> GetCandidateById([FromRoute] Guid id, CancellationToken token)
        {


            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate.MapToCandidateResponse());

        }

        [HttpGet(ApiEndpoints.V1.CandidateEndpoints.GetAllCandidates, Name = "GetAllCandidates")]
        public async Task<IActionResult> GetAllCandidatesFullProfile([FromQuery] GetAllCandidatesRequest request, CancellationToken token)
        {
            var options = request.MapToOptions();
            var candidates = await _candidateService.GetAllCandidatesFullProfile(options);
            var candidatesCount = await _candidateService.GetCandidatesCountFullProfileAsync(options);

            if (candidates == null)
            {
                return NotFound();
            }

            var response = candidates.MapToCandidatesResponse(request.Page, request.PageSize, candidatesCount);
            response.Links = _linkService.GenerateLinks("GetAllCandidates", Url, request.Page, request.PageSize, candidatesCount);
            return Ok(response);

        }


    }
}
