using CV.Api;
using CV.Application.Services;
using CV.Application.Services.CandidateService;
using CV_backend.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace CV_backend.Controllers.Candidates
{
    [ApiController]
    public class CandidatesController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICandidateService _candidateService;
        public CandidatesController(IUserService userService, ICandidateService candidateService)
        {
            _userService = userService;
            _candidateService = candidateService;
        }

        [HttpGet(ApiEndpoints.Candidate.GetFullProfile)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            throw new NotImplementedException();

        }  
        [HttpGet(ApiEndpoints.Candidate.GetCandidateById)]
        public async Task<IActionResult> GetCandidateById([FromRoute] Guid id, CancellationToken token)
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate.MapToCandidateResponse());

        }
    }
}
