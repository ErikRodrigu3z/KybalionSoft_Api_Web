﻿using KybalionSoft.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KybalionSoft.Services.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _db { get; set; }
        public RepositoryBase(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public IQueryable<T> FindAll()
        {
            return _db.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }



    }
}
