namespace Excella.Lean.Dal
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public static class ExtensionMethods
    {
        public static IQueryable<TEntity> IncludeMulti<TEntity>(this IQueryable<TEntity> a, params string[] includes)
            where TEntity : class
        {
            var query = a;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public static IQueryable<TEntity> IncludeMulti<TEntity>(this IQueryable<TEntity> a, params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            var query = a;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
