using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LibraryAppv2.Repository
{
    interface IRepository<TEntity> where TEntity : class
    {
        public TEntity Get(int Id);
        public IEnumerable<TEntity> GetAll();
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        public void Add(TEntity entity);
        public void AddRange(IEnumerable<TEntity> entities);

        public void Remove(TEntity entity);
        public void RemoveRange(IEnumerable<TEntity> entities);
    }
}
