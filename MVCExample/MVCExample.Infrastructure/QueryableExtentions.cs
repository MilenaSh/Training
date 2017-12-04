using AutoMapper.QueryableExtensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MVCExample.Infrastructure
{
    public static class QueryableExtentions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfiguration.Configuration, membersToExpand);
        }
    }
}
