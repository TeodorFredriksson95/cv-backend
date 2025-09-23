using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services.ApiKeyService
{
    public interface IApiKeyService
    {
        Task<bool> IsApiKeyRevoked(string apiKey);
    }
}
