using ProductManager.Domain.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ProductManager.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll(PaginationModel pagination);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
