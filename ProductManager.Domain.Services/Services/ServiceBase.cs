using ProductManager.Domain.Core.Interfaces.Repositories;
using ProductManager.Domain.Core.Interfaces.Services;
using ProductManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Services.Services
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        public virtual IEnumerable<TEntity> GetAll(PaginationModel pagination)
        {
            return _repository.GetAll(pagination);
        }
        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }
        public virtual void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
        public virtual void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }
        public virtual void Dispose()
        {
            _repository.Dispose();
        }

    }
}
