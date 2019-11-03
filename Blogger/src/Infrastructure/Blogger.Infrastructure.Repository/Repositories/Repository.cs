
using Blogger.Core.Application.Ports.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Infrastructure.Persistence;
using Blogger.Core.Domain.Models;

namespace Blogger.Infrastructure.Repository.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly BloggerContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(BloggerContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            if(entity != null)
            {
                _dbSet.Add(entity);
            }
        }
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            if(entities != null)
            {
                var list = entities.ToList();
                _dbSet.AddRange(list);
            }
        }

        public virtual void Update(TEntity entity)
        {
            if(entity != null)
            {
                _dbSet.Update(entity);
            }
        }
        public virtual void Remove(TEntity entity)
        {
            if(entity == null)
                return;

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }

        public virtual void Remove(int id)
        {
            var entity = new TEntity { Id = id };

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var query = _dbSet.Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
