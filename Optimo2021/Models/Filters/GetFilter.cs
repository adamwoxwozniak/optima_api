using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optimo2021.Models.Filters
{
    public class GetFilter
    {
        public string Columns { get; set; }
        public string Table { get; set; }
        public string Where { get; set; }
        public string Sort { get; set; }
    }
}
