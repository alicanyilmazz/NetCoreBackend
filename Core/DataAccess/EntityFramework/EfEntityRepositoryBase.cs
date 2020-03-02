using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<Tentity, TContext> : IEntityRepository<Tentity> where Tentity : class, IEntity, new() where TContext : DbContext, new()
    {
        public void Add(Tentity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Tentity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<Tentity>().SingleOrDefault(filter);
            }
        }

        public IList<Tentity> GetList(Expression<Func<Tentity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<Tentity>().ToList() : context.Set<Tentity>().Where(filter).ToList();
            }
        }

        public void Update(Tentity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
