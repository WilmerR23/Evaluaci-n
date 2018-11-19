using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using GH.Models;

namespace GH.Services
{
    public interface IApiDbQuery
    {
        IQueryable<TEntity> Get<TEntity>(ApiQueryOption queryOption, Func<IQueryable<TEntity>, IQueryable<TEntity>> callBack = null, bool filterDeleted = true)
            where TEntity : class;
    }

    public class ApiDbQuery : IApiDbQuery
    {
        private readonly PreguntasContext _PreguntasContext;
        private readonly IApiQueryResultFilter _apiQueryResultFilter;
        private int count = 0;
        public ApiDbQuery(PreguntasContext PreguntasContext, IApiQueryResultFilter apiQueryResultFilter)
        {
            _PreguntasContext = PreguntasContext;
            _apiQueryResultFilter = apiQueryResultFilter;
        }

        private IQueryable<TEntity> ApplyApiQueryOption<TEntity>(ApiQueryOption queryOption, IQueryable<TEntity> queryResult) where TEntity : class
        {
            if (queryOption == null)
                queryOption = new ApiQueryOption();

            queryResult = _apiQueryResultFilter.Filter(queryResult, queryOption);
            this.count = queryResult.Count();

            return queryResult;
        }

        public IQueryable<TEntity> Get<TEntity>(ApiQueryOption queryOption, Func<IQueryable<TEntity>, IQueryable<TEntity>> callBack = null, bool filterDeleted = true) where TEntity : class
        {
            var context = _PreguntasContext;
            var queryResult = context.Set<TEntity>().AsQueryable();
            callBack?.Invoke(queryResult);

            return ApplyApiQueryOption(queryOption, queryResult);
        }
    }
}

