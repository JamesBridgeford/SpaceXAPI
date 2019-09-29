using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceXAPI.Models
{
    public class ApiPagingModel<T> : PagingModel
    {
        public ICollection<string> Filters { get; internal set; }
        public ICollection<T> Results { get; set; }
    }
}
