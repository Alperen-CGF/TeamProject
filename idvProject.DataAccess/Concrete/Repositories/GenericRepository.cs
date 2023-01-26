using idvProject.DataAccess.Abstract;
using idvProject.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace idvProject.DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        //DataBaseContext context = new DataBaseContext();

        //DbSet<T> _object;

        //public GenericRepository()
        //{
        //    _object = context.Set<T>();
        //}

        public void Delete(T t)
        {
            using (DataBaseContext context = new DataBaseContext()) 
            {
                var deletedEntity = context.Entry(t);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
            
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                return context.Set<T>().Where(filter).ToList();
            }
        }

        public List<T> GetAll()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Insert(T t)
        {
            using (DataBaseContext context=new DataBaseContext())
            {
                var addedEntity = context.Entry(t);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(T t)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var updatedEntity = context.Entry(t);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
