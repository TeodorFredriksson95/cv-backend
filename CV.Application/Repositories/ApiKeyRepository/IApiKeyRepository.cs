using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Repositories.ApiKeyRepository
{
    public interface IApiKeyRepository
    {
        Task<bool> IsApiKeyRevoked(string apiKey);
    }
}
