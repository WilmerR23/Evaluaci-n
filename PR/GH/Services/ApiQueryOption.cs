using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GH.Services
{
    public class ApiQueryOption 
    {
        public string Where { get; set; }
        //public string OrderBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public ApiQueryOption()
        {
            Page = 1;
            PageSize = int.MaxValue;
            //OrderBy = "Id";
        }
    }
}
