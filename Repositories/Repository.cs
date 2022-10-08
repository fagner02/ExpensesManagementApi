using ExpensesManagementApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpensesManagementApi.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        public Repository(Context context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.UpdateRange(entities);
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = includes.Aggregate(_context.Set<TEntity>().AsQueryable(), AddIncludes);
            return query;
        }

        private IQueryable<TEntity> AddIncludes(IQueryable<TEntity> query, Expression<Func<TEntity, object>> include)
        {
            return query.Include(include);
        }

        private static string GetPath(MemberExpression memberExpression)
        {
            string path = "";
            if(memberExpression.Expression is MemberExpression)
            {
                path = GetPath((MemberExpression)memberExpression.Expression)+".";
            }
            path += ((PropertyInfo)memberExpression.Member).Name;
            return path;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
