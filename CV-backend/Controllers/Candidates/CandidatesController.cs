﻿using CV.Api;
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

namespace CV_backend.Controllers.Candidates
{
    [Authorize]
    [ApiController]
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly ITechStackService _techStackService;
        private readonly IWorkExperienceService _workExperienceService;
        public CandidatesController(ICandidateService candidateService, ITechStackService techStackService, IWorkExperienceService workExperienceService)
        {
            _candidateService = candidateService;
            _techStackService = techStackService;
            _workExperienceService = workExperienceService;
        }

        [HttpGet(ApiEndpoints.WorkExperience.GetAllWorkExperiences)]
        public async Task<IActionResult> GetAllWorkExperiences([FromQuery] GetAllWorkExperiencesRequest request, CancellationToken token)
        {


            var options = request.MapToOptions();
            var workExperiences = await _workExperienceService.GetWorkExperienceListAsync(options);
            if (workExperiences == null)
            {
                return NotFound();
            }

            var workExperiencesCount = await _workExperienceService.GetWorkExperiencesCountAsync(options.JobTitle, options.Category, options.Company);

            return Ok(workExperiences.MapToWorkExperiencesResponse(request.Page, request.PageSize, workExperiencesCount));
        }

        [HttpGet(ApiEndpoints.WorkExperience.GetWorkExperienceById)]
        public async Task<IActionResult> GetWorkExperienceById([FromRoute] int id, CancellationToken token)
        {
            var workExperience = await _workExperienceService.GetWorkExperienceByIdAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return Ok(workExperience.MapToWorkExperienceResponse());
        }

        [HttpGet(ApiEndpoints.TechStack.GetAllTech)]
        public async Task<IActionResult> GetAllTech([FromQuery] GetAllTechRequest request, CancellationToken token)
        {
            var options = request.MapToOptions();
            var allTech = await _techStackService.GetTechStackList(options);

            var techListCount = await _techStackService.GetTechStackCountAsync(options.TechName);

            if (allTech == null)
            {
                return NotFound();
            }
            return Ok(allTech.MapToTechStackResponses(request.Page, request.PageSize, techListCount));
        }

        [HttpGet(ApiEndpoints.TechStack.GetTechById)]
        public async Task<IActionResult> GetTechById([FromRoute] int id, CancellationToken token)
        {
            var techById = await _techStackService.GetTechStackById(id);
            if (techById == null)
            {
                return NotFound();
            }
            return Ok(techById.MapToTechStackResponse());
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

        [HttpGet(ApiEndpoints.Candidate.GetAllCandidateFullProfile)]
        public async Task<IActionResult> GetAllCandidatesFullProfile([FromQuery] GetAllCandidatesRequest request, CancellationToken token)
        {
            var options = request.MapToOptions();
            var candidates = await _candidateService.GetAllCandidatesFullProfile(options);
            var candidatesCount = await _candidateService.GetCandidatesCountFullProfileAsync(options);

            if (candidates == null)
            {
                return NotFound();
            }
            return Ok(candidates.MapToCandidatesResponse(request.Page, request.PageSize, candidatesCount));

        }


    }
}
