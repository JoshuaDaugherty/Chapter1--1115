using System.Linq.Expressions;

namespace TripLog2.Models.DataAccess
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, Object>> OrderBy {get;set;}

        public Expression<Func<T,bool>> Where { get; set; }

        private string[] includes = Array.Empty<string>();

        public string Incudes { set => includes = value.Replace(" ", "").Split(','); }

        public string[] GetIncudes() => includes;

        public bool HasWhere => Where != null;

        public bool HasOrderBy => OrderBy != null; 
    }
}
