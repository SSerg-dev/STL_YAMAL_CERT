using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SmartQA.DB.Util
{
    public static class EfUtils
    {        
        public static IQueryable<TEntity> Query<TEntity>(DataContext context) where TEntity : class        
            => context.Set<TEntity>().IgnoreQueryFilters();
                
        // https://stackoverflow.com/questions/42240968/entity-framework-filter-by-primarykey
        public static Expression<Func<T, bool>> BuildKeyPredicate<T>(DataContext context, object[] id)
        {
            var keyProperties = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
            var parameter = Expression.Parameter(typeof(T), "e");
            var body = keyProperties
                // e => e.PK[i] == id[i]
                .Select((p, i) => Expression.Equal(
                    Expression.Property(parameter, p.Name),
                    Expression.Convert(
                        Expression.PropertyOrField(Expression.Constant(new { id = id[i] }), "id"),
                        p.ClrType)))
                .Aggregate(Expression.AndAlso);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        public static object Find<TEntity>(DataContext context, object pkey) where TEntity : class
            => Query<TEntity>(context).SingleOrDefault(BuildKeyPredicate<TEntity>(context, new[] {pkey}));


    }
}