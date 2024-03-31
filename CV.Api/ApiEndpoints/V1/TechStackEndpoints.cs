using System.Runtime.Intrinsics.Arm;

namespace CV_backend.ApiEndpoints.V1
{
    public class TechStackEndpoints
    {
        private const string ApiBase = "api/v1";

        public const string Base = $"{ApiBase}/tech-stack";
        public const string GetAllTech = Base;
        public const string GetTechById = $"{Base}/{{id}}";
    }
}
