﻿namespace CV.Api
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
            public const string Base = $"{ApiBase}/candidate";
            public const string GetFullProfile = $"{Base}/full-profile";
            public const string GetCandidateById = $"{Base}/{{id}}";

        }
    }
}
