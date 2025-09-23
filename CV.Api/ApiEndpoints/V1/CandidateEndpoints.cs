using System.Runtime.Intrinsics.Arm;

namespace CV_backend.ApiEndpoints.V1
{
    public class CandidateEndpoints
    {
        private const string ApiBase = "api/v1";

        public const string Base = $"{ApiBase}/candidates";
        public const string GetAllCandidates = $"{ApiBase}/candidates";
        public const string GetCandidateById = $"{Base}/{{id}}";
    }
}
