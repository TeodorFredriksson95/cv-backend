using System.Runtime.Intrinsics.Arm;

namespace CV_backend.ApiEndpoints.V1
{
    public class WorkExperiencesEndpoints
    {
        private const string ApiBase = "api/v1";

        public const string Base = $"{ApiBase}/work-experiences";
        public const string GetAllWorkExperiences = Base;
        public const string GetWorkExperienceById = $"{Base}/{{id}}";
    }
}
