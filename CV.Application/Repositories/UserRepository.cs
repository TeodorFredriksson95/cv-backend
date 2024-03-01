using CV.Application.Database;
using CV.Application.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> CreateUseAsync(User user, CancellationToken token = default)
        {
            throw new NotImplementedException();
            //using var connection = await _connectionFactory.CreateConnectionAsync();
            //using var transaction = connection.BeginTransaction();

            //var result = await connection.ExecuteAsync(new CommandDefinition(
            //    """
            //    insert into users (id, slug, title, yearofrelease)
            //    values (@Id, @Slug, @Title, @YearOfRelease)
            //    """, movie, cancellationToken: token));

            //if (result > 0)
            //{
            //    foreach (var genre in movie.Genres)
            //    {
            //        await connection.ExecuteAsync(new CommandDefinition(
            //   """
            //    insert into genres (movieId, name)
            //    values (@MovieId, @Name)
            //    """, new { MovieId = movie.Id, Name = genre }, cancellationToken: token));
            //    }
            //}

            //transaction.Commit();
            //return result > 0;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            using var transaction = connection.BeginTransaction();

            var result = await connection.QueryAsync(new CommandDefinition("""
                select * FROM users
                """, cancellationToken: token));
            Console.Write(result);
            return result.Select(x => new User
            {
                Id = x.userid,
                CountryOfResidency = x.countryofresidencyid.ToString(),
                Email = x.email,
                FirstName = x.firstname,
                LastName = x.lastname,
            });

        }
    }
}
