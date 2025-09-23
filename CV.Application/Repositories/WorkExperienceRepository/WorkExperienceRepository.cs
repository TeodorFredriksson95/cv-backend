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

        public async Task<IEnumerable<WorkExperience>> GetAllWorkExperiences(GetAllWorkExperiencesOptions options)
        {

            var sql = $@"SELECT
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
            WHERE (@CompanyName IS NULL OR comp.company_name ILIKE ('%' || @CompanyName || '%'))
                AND (@JobTitle IS NULL OR jt.job_title_name ILIKE ('%' || @JobTitle || '%'))
                AND (@Category IS NULL OR jc.job_category_name ILIKE ('%' || @Category || '%'))
                limit @PageSize
                offset @PageOffset";

            using var connection = await _connectionFactory.CreateConnectionAsync();
            var workExperiences = (await connection.QueryAsync<WorkExperience>(sql, new
            {
                CompanyName = options.Company,
                JobTitle = options.JobTitle,
                Category = options.Category,
                PageSize = options.PageSize,
                PageOffset = (options.Page - 1) * options.PageSize,
            })).ToList();

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

        public async Task<int> GetWorkExperiencesCountAsync(string? jobTitle, string? jobCategory, string? companyName)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var sql = $@"SELECT count(we.work_experience_id)
            FROM work_experience we
            JOIN companies comp ON we.company_id = comp.company_id
            JOIN job_titles jt ON we.job_title_id = jt.job_title_id
            JOIN job_categories jc ON jt.job_category_id = jc.job_category_id
            WHERE (@CompanyName IS NULL OR comp.company_name ILIKE ('%' || @CompanyName || '%'))
                AND (@JobTitle IS NULL OR jt.job_title_name ILIKE ('%' || @JobTitle || '%'))
                AND (@Category IS NULL OR jc.job_category_name ILIKE ('%' || @Category || '%'))";

            return await connection.QuerySingleAsync<int>(sql, new
            {
                CompanyName = companyName,
                JobTitle = jobTitle,
                Category = jobCategory,
            });

        }
    }
}
