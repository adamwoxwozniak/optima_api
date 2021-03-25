using Optimo2021.Models.Filters;
using SqlKata;
using SqlKata.Compilers;

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
            var compiler = new SqlServerCompiler();

            var query = new Query(filter.Table).SelectRaw(filter.Columns);

            if(filter.Where.Count > 0)
            {
                foreach(var where in filter.Where)
                {
                    query.Where(where.Column, where.Operator, where.Value);
                }
            }

            if (!string.IsNullOrEmpty(filter.Sort))
                query.OrderByRaw(filter.Sort);

            if (filter.Join.Count > 0)
            {
                foreach(var join in filter.Join)
                {
                    query.Join(join.JoinTable, join.SourceColumn, join.JoinColumn);
                }
            }

            return compiler.Compile(query).ToString();
        }
    }
}
