using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using CV.Application.Database;
using CV.Application.Repositories;
using CV.Application.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Application.Services.CandidateService;
using CV.Application.Repositories.CandidateRepository;
using CV.Application.Repositories.ApiKeyRepository;
using CV.Application.Services.ApiKeyService;
using CV.Application.Repositories.TechStackRepository;
using CV.Application.Services.TechStackService;
using CV.Application.Repositories.WorkExperienceRepository;
using CV.Application.Services.WorkExperienceService;

namespace CV.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();

            services.AddSingleton<ICandidateRepository, CandidateRepository>();
            services.AddSingleton<ICandidateService, CandidateService>();
            
            services.AddSingleton<IApiKeyRepository, ApiKeyRepository>();
            services.AddSingleton<IApiKeyService, ApiKeyService>();

            services.AddSingleton<ITechStackRepository, TechStackRepository>();
            services.AddSingleton<ITechStackService, TechStackService>();

            services.AddSingleton<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddSingleton<IWorkExperienceService, WorkExperienceService>();



            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDbConnectionFactory>(_ => new NpgsqlConnectionFactory(connectionString));
            services.AddSingleton<DbInitializer>();
            return services;
        }
    }
}
