using System;
namespace Api.Models
{
    public class RequestPageAttr
    {
        public string Page { get; set; }
        public string PerPage { get; set; }
        public string TotalPages { get; set; }
        public string Total { get; set; }
    }
}
