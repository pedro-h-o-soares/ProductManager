using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Core.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        public TEntity GetById(int id);

        public IEnumerable<TEntity> GetAll();

        public void Add(TEntity obj);

        public void Update(TEntity obj);

        public void Remove(TEntity obj);

        public void Dispose();
    }
}
