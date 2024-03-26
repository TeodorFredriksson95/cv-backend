using CV.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services.WorkExperienceService
{
    public interface IWorkExperienceService
    {
        Task<WorkExperience> GetWorkExperienceByIdAsync(int id);
        Task<IEnumerable<WorkExperience>> GetWorkExperienceListAsync(GetAllWorkExperiencesOptions options);
        Task<int> GetWorkExperiencesCountAsync(string? jobTitle, string? jobCategory, string? companyName);
    }
}
