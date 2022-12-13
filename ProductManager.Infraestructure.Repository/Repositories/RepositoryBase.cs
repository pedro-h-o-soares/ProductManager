using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Core.Interfaces.Repositories;
using ProductManager.Domain.Models;
using ProductManager.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infraestructure.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Base
    {
        private readonly SqlContext _context;

        public RepositoryBase(SqlContext Context)
        {
            _context = Context;
        }

        public void Add(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll(PaginationModel pagination)
        {
            var page = pagination.Page - 1;
            var pageSize = pagination.PageSize;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (page > 0)
            {
                query = query.Skip(page*pageSize);
            }

            if (pageSize > 0)
            {
                query = query.Take(pageSize);
            }

            return query.ToList();
        }
        
        public void Update(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(TEntity obj)
        {
            try
            {
                obj.Active = false;
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
