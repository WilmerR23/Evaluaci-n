using System;
using System.Threading.Tasks;

namespace GH.Extensions
{
    public interface IUnitOfWork
    {
        Task<T> InTransactionAsync<T>(Func<T> action);
        T InTransaction<T>(Func<T> action);
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextFactory _dbContextFactory;

        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public T InTransaction<T>(Func<T> action)
        {
            var context = _dbContextFactory.GetContext();

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var result = action();
                    context.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                    _dbContextFactory.Dispose();
                }
            }
        }

        public async Task<T> InTransactionAsync<T>(Func<T> action)
        {
            var context = _dbContextFactory.GetContext();

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var result = await Task.Run(action);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                    _dbContextFactory.Dispose();
                }
            }
        }
    }
}
