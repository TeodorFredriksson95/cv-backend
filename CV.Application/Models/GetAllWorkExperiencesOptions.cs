using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Models
{
    public class GetAllWorkExperiencesOptions
    {
        public string? Company { get; init; }
        public string? Category { get; init; }
        public string? JobTitle { get; init; }
        public string? SortField { get; init;}
        public SortOrder? SortOrder { get; init;}
        public int Page {  get; set; }
        public int PageSize { get; set; }
    }

    public enum SortOrder
    {
        Unsorted,
        Ascending,
        Descending,
    }
}
