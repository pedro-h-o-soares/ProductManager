using ProductManager.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Interfaces
{
    public interface IApplicationServiceProduct
    {
        void Add(ProductDTO obj);

        ProductDTO GetById(int id);

        IEnumerable<ProductDTO> GetAll();

        void Update(ProductDTO obj);

        void Remove(ProductDTO obj);

        void Dispose();
    }
}
