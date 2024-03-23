using CV.Application.Repositories.ApiKeyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services.ApiKeyService
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IApiKeyRepository _apiKeyRepository;
        public ApiKeyService(IApiKeyRepository apiKeyRepository)
        {
            _apiKeyRepository = apiKeyRepository;
        }
        public async Task<bool> IsApiKeyRevoked(string apiKey)
        {
           return await _apiKeyRepository.IsApiKeyRevoked(apiKey);
        }
    }
}
