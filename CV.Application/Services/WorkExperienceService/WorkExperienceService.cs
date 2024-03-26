using CV.Application.Models;
using CV.Application.Repositories.WorkExperienceRepository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services.WorkExperienceService
{
    public class WorkExperienceService : IWorkExperienceService
    {
    private readonly IWorkExperienceRepository _workExperienceRepository;
        private readonly IValidator<GetAllWorkExperiencesOptions> _optionsValidator;

        public WorkExperienceService(IWorkExperienceRepository workExperienceRepository, IValidator<GetAllWorkExperiencesOptions> optionsValidator)
        {
            _workExperienceRepository = workExperienceRepository;
            _optionsValidator = optionsValidator;
        }

        public async Task<WorkExperience> GetWorkExperienceByIdAsync(int id)
        {
            return await _workExperienceRepository.GetWorkExperienceById(id);
        }

        public async Task<IEnumerable<WorkExperience>> GetWorkExperienceListAsync(GetAllWorkExperiencesOptions options)
        {
            await _optionsValidator.ValidateAndThrowAsync(options);
            return await _workExperienceRepository.GetAllWorkExperiences(options);
        }

        public Task<int> GetWorkExperiencesCountAsync(string? jobTitle, string? jobCategory, string? companyName)
        {
            return _workExperienceRepository.GetWorkExperiencesCountAsync(jobTitle, jobCategory, companyName); 
        }
    }
}
