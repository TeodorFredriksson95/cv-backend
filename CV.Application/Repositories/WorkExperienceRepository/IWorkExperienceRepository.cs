using CV.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Repositories.WorkExperienceRepository
{
    public interface IWorkExperienceRepository
    {
        Task<WorkExperience> GetWorkExperienceById(int id);
        Task<IEnumerable<WorkExperience>> GetAllWorkExperiences();
    }
}
