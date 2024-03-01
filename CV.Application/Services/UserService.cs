using CV.Application.Models;
using CV.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
           _repository = repository;
        }
        public Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default)
        {
            return _repository.GetAllAsync(token);
        }
    }
}
