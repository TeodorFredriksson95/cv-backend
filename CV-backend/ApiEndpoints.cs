namespace CV.Api
{
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";

        public static class User
        {
            public const string Base = $"{ApiBase}/users";
            public const string Create = Base;
            public const string Get = $"{Base}/{{idOrSlug}}";
            public const string GetAll = Base;

            public const string Update = $"{Base}/{{id:guid}}";

            public const string Delete = $"{Base}/{{id:guid}}";
        }  
        
        public static class Candidate
        {
            public const string Base = $"{ApiBase}/candidates";
            public const string GetCandidateById = $"{Base}/{{id}}";
            public const string GetAllCandidateFullProfile = $"{Base}/full-profile";
        }

        public static class TechStack
        {
            public const string Base = $"{ApiBase}/tech-stack";
            public const string GetAllTech = Base;
            public const string GetTechById = $"{Base}/{{id}}";
        }
        public static class WorkExperience
        {
            public const string Base = $"{ApiBase}/work-experiences";
            public const string GetAllWorkExperiences = Base;
            public const string GetWorkExperienceById = $"{Base}/{{id}}";
        }
    }
}
