using CV.Application.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Repositories.ApiKeyRepository
{
    public class ApiKeyRepository : IApiKeyRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public ApiKeyRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> IsApiKeyRevoked(string apiKey)
        {
            const string sql = @"
                    SELECT 
                        revoked
                    FROM api_keys
                    WHERE api_key = @ApiKey";

            using var dbConnection = await _dbConnectionFactory.CreateConnectionAsync();
            var isApiKeyRevoked = await dbConnection.QuerySingleOrDefaultAsync<bool?>(sql, new { ApiKey = apiKey });

            return isApiKeyRevoked ?? false;
        }

    }
}
