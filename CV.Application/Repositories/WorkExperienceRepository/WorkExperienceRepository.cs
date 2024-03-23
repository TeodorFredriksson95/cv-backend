using CV.Application.Database;
using CV.Application.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Repositories.WorkExperienceRepository
{
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public WorkExperienceRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<WorkExperience>> GetAllWorkExperiences()
        {
            var sql = @"SELECT
                we.work_experience_id AS WorkExperienceId, 
                we.description, 
                we.start_date AS StartDate, 
                we.end_date AS EndDate, 
                comp.company_name AS Company, 
                jt.job_title_name AS JobTitle, 
                jc.job_category_name AS Category
            FROM work_experience we
            JOIN companies comp ON we.company_id = comp.company_id
            JOIN job_titles jt ON we.job_title_id = jt.job_title_id
            JOIN job_categories jc ON jt.job_category_id = jc.job_category_id";

            using var connection = await _connectionFactory.CreateConnectionAsync();
            var workExperiences = (await connection.QueryAsync<WorkExperience>(sql)).ToList();

            return workExperiences;

        }

        public async Task<WorkExperience> GetWorkExperienceById(int id)
        {
            var sql = @"SELECT
                we.work_experience_id AS WorkExperienceId, 
                we.description, 
                we.start_date AS StartDate, 
                we.end_date AS EndDate, 
                comp.company_name AS Company, 
                jt.job_title_name AS JobTitle, 
                jc.job_category_name AS Category
            FROM work_experience we
            JOIN companies comp ON we.company_id = comp.company_id
            JOIN job_titles jt ON we.job_title_id = jt.job_title_id
            JOIN job_categories jc ON jt.job_category_id = jc.job_category_id
            WHERE we.work_experience_id = @WorkExperienceId";

            using var connection = await _connectionFactory.CreateConnectionAsync();

            var workExperience = connection.QueryFirstOrDefault<WorkExperience>(sql, new {WorkExperienceId = id});
            return workExperience;
        }
    }
}
