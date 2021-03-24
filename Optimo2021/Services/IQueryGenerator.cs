using Optimo2021.Models.Filters;

namespace Optimo2021.Services
{
    public interface IQueryGenerator
    {
        string SelectQuery(GetFilter filter);
    }

    public class QueryGenerator : IQueryGenerator
    {
        public string SelectQuery(GetFilter filter)
        {
            if(!string.IsNullOrEmpty(filter.Where))
            {
                if(!string.IsNullOrEmpty(filter.Sort))
                {
                    return $"select {filter.Columns} from CDN.{filter.Table} where {filter.Where} order by {filter.Sort}";
                }
                else
                {
                    return $"select {filter.Columns} from CDN.{filter.Table} where {filter.Where}";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(filter.Sort))
                {
                    return $"select {filter.Columns} from CDN.{filter.Table} order by {filter.Sort}";
                }
                else
                {
                    return $"select {filter.Columns} from CDN.{filter.Table}";
                }
            }
        }
    }
}
