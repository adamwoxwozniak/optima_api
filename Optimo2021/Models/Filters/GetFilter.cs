using System.Collections.Generic;

namespace Optimo2021.Models.Filters
{
    public class GetFilter
    {
        public string Columns { get; set; }
        public string Table { get; set; }
        public List<GetWhere> Where { get; set; }
        public string Sort { get; set; }
        public List<GetJoin> Join { get; set; }
    }

    public class GetWhere
    {
        public string Column { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }
    }

    public class GetJoin
    {
        public string JoinColumn { get; set; }
        public string SourceColumn { get; set; }
        public string JoinTable { get; set; }
    }
}
