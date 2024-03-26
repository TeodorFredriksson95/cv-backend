using CV.Application.Database;
using CV.Application.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Repositories.TechStackRepository
{
    public class TechStackRepository : ITechStackRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public TechStackRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory;
        }
        public async Task<TechStack> GetTechStackById(int techId)
        {
            var sql = @"SELECT " +
                "tech_stack_name AS TechStackName," +
                "tech_stack_id AS TechStackId " +
                "FROM tech_stack " +
                "WHERE tech_stack_id = @TechId";

            using var connection = await _connectionFactory.CreateConnectionAsync();
            var techStack = await connection.QueryFirstOrDefaultAsync<TechStack>(sql, new { TechId = techId });
            return techStack;
        }

        public async Task<int> GetTechStackCountAsync(string? techName)
        {
            var sql = @"SELECT " +
                         "count(tech_stack_id)" +
                         " FROM tech_stack" +
                         " WHERE (@TechStackName IS NULL OR tech_stack_name ILIKE ('%' || @TechStackName || '%'))";

            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleAsync<int>(sql, new { TechStackName = techName });
        }

        public async Task<IEnumerable<TechStack>> GetTechStackList(GetAllTechStackOptions options)
        {
            var sql = @"SELECT " +
                          "tech_stack_name AS TechStackName," +
                          "tech_stack_id AS TechStackId" +
                          " FROM tech_stack" +
                          " WHERE (@TechStackName IS NULL OR tech_stack_name ILIKE ('%' || @TechStackName || '%'))" +
                          " limit @PageSize" +
                          " offset @PageOffset";

            using var connection = await _connectionFactory.CreateConnectionAsync();
            var techStack = (await connection.QueryAsync<TechStack>(sql, new { TechStackName = options.TechName, PageSize = options.PageSize, PageOffset = (options.Page - 1) * options.PageSize })).ToList();
            return techStack;
        }
    }
}
