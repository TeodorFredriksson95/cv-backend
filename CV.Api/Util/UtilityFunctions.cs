using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CV_backend.Util
{
    public class UtilityFunctions
    {
        public Dictionary<string, string> LinksHelper(string endpoint, IUrlHelper urlHelper, int page, int pageSize, int totalCount)
        {
            string baseUrl = urlHelper.Link(endpoint, null);
            Dictionary<string, string> apiLinks = new Dictionary<string, string>();

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            apiLinks["self"] = $"{baseUrl}?page={page}";
            apiLinks["first"] = $"{baseUrl}?page=1";
            apiLinks["last"] = $"{baseUrl}?page={totalPages}";

            if (page > 1)
            {
                apiLinks["prev"] = $"{baseUrl}?page={page - 1}&pageSize={pageSize}";
            }

            if (page < totalPages)
            {
                apiLinks["next"] = $"{baseUrl}?page={page + 1}&pageSize={pageSize}";
            }
            return apiLinks;
        }
    }
}
