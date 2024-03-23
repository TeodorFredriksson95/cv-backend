using CV.Application.Models;
using CV.Application.Repositories.WorkExperienceRepository;
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

        public WorkExperienceService(IWorkExperienceRepository workExperienceRepository)
        {
            _workExperienceRepository = workExperienceRepository;
        }

        public async Task<WorkExperience> GetWorkExperienceByIdAsync(int id)
        {
            return await _workExperienceRepository.GetWorkExperienceById(id);
        }

        public async Task<IEnumerable<WorkExperience>> GetWorkExperienceListAsync()
        {
            return await _workExperienceRepository.GetAllWorkExperiences();
        }
    }
}
