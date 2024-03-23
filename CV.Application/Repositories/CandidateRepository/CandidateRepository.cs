using CV.Application.Database;
using CV.Application.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Repositories.CandidateRepository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public CandidateRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesFullProfile(CancellationToken cancellationToken = default)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var candidatesQuery = @"
        SELECT 
            u.public_user_id AS PublicUserId,
            u.firstname AS Firstname,
            u.lastname AS Lastname,
            u.email AS Email,
            u.open_for_work AS OpenToWork,
            c.country_name AS Country
        FROM users u
        LEFT JOIN countries c ON u.country_id = c.country_id";

            var candidates = (await connection.QueryAsync<Candidate>(candidatesQuery)).ToList();

            foreach (var candidate in candidates)
            {
                candidate.WorkExperience = (await connection.QueryAsync<WorkExperience>(@"
            SELECT 
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
            WHERE we.public_user_id = @PublicUserId", new { PublicUserId = candidate.PublicUserId })).ToList();

                candidate.TechStack = (await connection.QueryAsync<TechStack>(@"
            SELECT 
                ts.tech_stack_id AS TechStackId, 
                ts.tech_stack_name AS TechStackName
            FROM users_tech_stack uts
            JOIN tech_stack ts ON uts.tech_stack_id = ts.tech_stack_id
            WHERE uts.public_user_id = @PublicUserId", new { PublicUserId = candidate.PublicUserId })).ToList();
            }

            return candidates;
        }


        public Task<IEnumerable<Candidate>> GetCandidate(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> GetCandidateByPublicIdAsync(Guid publicUserId)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var candidateQuery = @"
                    SELECT 
                        u.public_user_id AS PublicUserId,
                        u.firstname AS Firstname,
                        u.lastname AS Lastname,
                        u.email AS Email,
                        u.open_for_work AS OpenToWork,
                        c.country_name AS Country
                    FROM users u
                    LEFT JOIN countries c ON u.country_id = c.country_id
                    WHERE u.public_user_id = @PublicUserId";

            var candidate = await connection.QueryFirstOrDefaultAsync<Candidate>(
                candidateQuery,
                new { PublicUserId = publicUserId });

            if (candidate != null)
            {
                var workExperiencesQuery = @"
                    SELECT 
                        we.Work_Experience_Id AS WorkExperienceId, 
                        we.Description, 
                        we.Start_Date AS StartDate, 
                        we.End_Date AS EndDate, 
                        c.Company_Name AS Company, 
                        jt.Job_Title_Name AS JobTitle, 
                        jc.Job_Category_Name AS Category
                    FROM work_experience we
                    JOIN Companies c ON we.Company_Id = c.Company_Id
                    JOIN Job_Titles jt ON we.Job_Title_Id = jt.Job_Title_Id
                    JOIN Job_Categories jc ON jt.Job_Category_Id = jc.Job_Category_Id
                    WHERE we.Public_User_Id = @PublicUserId";

                var workExperiences = await connection.QueryAsync<WorkExperience>(workExperiencesQuery, new { candidate.PublicUserId });
                candidate.WorkExperience = workExperiences.ToList();


                var techStacksQuery = @"
                        SELECT ts.tech_stack_id AS TechStackId, ts.tech_stack_name AS TechStackName
                        FROM users_tech_stack uts
                        JOIN tech_stack ts ON uts.tech_stack_id = ts.tech_stack_id
                        JOIN users u ON uts.public_user_id = u.public_user_id
                        WHERE u.public_user_id = @PublicUserId";

                candidate.TechStack = (await connection.QueryAsync<TechStack>(
                    techStacksQuery,
                    new { PublicUserId = candidate.PublicUserId })).ToList();

            }

            return candidate;
        }
    }
}
