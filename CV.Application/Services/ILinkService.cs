using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Services
{
    public interface ILinkService
    {
        Dictionary<string, string> GenerateLinks(string endpoint, IUrlHelper urlHelper, int page, int pageSize, int totalCount);

    }
}
