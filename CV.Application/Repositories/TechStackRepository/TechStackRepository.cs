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
            var techStack = await connection.QueryFirstOrDefaultAsync<TechStack>(sql, new {TechId = techId});
            return techStack;
        } 

    public async Task<IEnumerable<TechStack>> GetTechStackList()
        {
            var sql = @"SELECT " +
                          "tech_stack_name AS TechStackName," +
                          "tech_stack_id AS TechStackId" +
                          " FROM tech_stack";

            using var connection = await _connectionFactory.CreateConnectionAsync();
            var techStack = (await connection.QueryAsync<TechStack>(sql)).ToList();
            return techStack;
        }
    }
}
