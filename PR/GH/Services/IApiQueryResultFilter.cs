using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;

namespace GH.Services
{
    public interface IApiQueryResultFilter
    {
        IQueryable<TEntity> Filter<TEntity>(IQueryable<TEntity> entitiesQuery, ApiQueryOption paginationInfo);
        //List<T> Filter<T>(List<T> personas, ApiQueryOption queryOption);
    }

    public class ApiQueryResultFilter : IApiQueryResultFilter
    {
        private readonly IUrlFilterToDynamicLinqParser _urlFilterToDynamicLinqParser;


        public ApiQueryResultFilter(IUrlFilterToDynamicLinqParser urlFilterToDynamicLinqParser)
        {
            _urlFilterToDynamicLinqParser = urlFilterToDynamicLinqParser;
        }

        public IQueryable<TEntity> Filter<TEntity>(IQueryable<TEntity> entitiesQuery, ApiQueryOption paginationInfo)
        {
            var query = entitiesQuery;
            var filterString = _urlFilterToDynamicLinqParser.Parse(paginationInfo.Where);
            if (!string.IsNullOrWhiteSpace(filterString))
                    query = entitiesQuery.Where(filterString);
            
            return query;
        }


    }
}