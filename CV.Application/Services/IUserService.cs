using CV.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default);
    }
}
