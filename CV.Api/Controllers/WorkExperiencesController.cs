using CV.Application.Services.CandidateService;
using CV.Application.Services.TechStackService;
using CV.Application.Services.WorkExperienceService;
using CV.Application.Services;
using CV.Contracts.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CV_backend.Mapping.WorkExperienceMapping;

namespace CV_backend.Controllers
{
    [Authorize]
    [ApiController]
    public class WorkExperiencesController : Controller
    {

        private readonly IWorkExperienceService _workExperienceService;
        private readonly ILinkService _linkService;

        public WorkExperiencesController(ICandidateService candidateService, ITechStackService techStackService, IWorkExperienceService workExperienceService, ILinkService linkService)
        {
            _workExperienceService = workExperienceService;
            _linkService = linkService;
        }

        [HttpGet(ApiEndpoints.V1.WorkExperiencesEndpoints.GetAllWorkExperiences, Name = "GetAllWorkExperiences")]
        public async Task<IActionResult> GetAllWorkExperiences([FromQuery] GetAllWorkExperiencesRequest request, CancellationToken token)
        {


            var options = request.MapToOptions();
            var workExperiences = await _workExperienceService.GetWorkExperienceListAsync(options);
            if (workExperiences == null)
            {
                return NotFound();
            }

            var workExperiencesCount = await _workExperienceService.GetWorkExperiencesCountAsync(options.JobTitle, options.Category, options.Company);
            var response = workExperiences.MapToWorkExperiencesResponse(request.Page, request.PageSize, workExperiencesCount);
            response.Links = _linkService.GenerateLinks("GetAllWorkExperiences", Url, request.Page, request.PageSize, workExperiencesCount);

            return Ok(response);
        }

        [HttpGet(ApiEndpoints.V1.WorkExperiencesEndpoints.GetWorkExperienceById)]
        public async Task<IActionResult> GetWorkExperienceById([FromRoute] int id, CancellationToken token)
        {
            var workExperience = await _workExperienceService.GetWorkExperienceByIdAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return Ok(workExperience.MapToWorkExperienceResponse());
        }
    }
}
