using ProductManager.Application.DTO.DTO;
using ProductManager.Application.Interfaces;
using ProductManager.Domain.Core.Services;
using ProductManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Service
{
    public class ApplicationServiceProduct : IApplicationServiceProduct
    {
        private readonly IServiceProduct _serviceProduct;
        private readonly IMapperProduct _mapperProduct;

        public ApplicationServiceProduct(IServiceProduct ServiceProduct, IMapperProduct MapperProduct)
        {
            _serviceProduct = ServiceProduct;
            _mapperProduct = MapperProduct;
        }

        public void Add(ProductDTO obj)
        {
            var objProduct = _mapperProduct.MapperToEntity(obj);
            _serviceProduct.Add(objProduct);
        }

        public void Dispose()
        {
            _serviceProduct.Dispose();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var objProducts = _serviceProduct.GetAll();
            return _mapperProduct.MapperListProducts(objProducts);
        }

        public ProductDTO GetById(int id)
        {
            var objProduct = _mapperProduct.MapperToEntity(GetById(id));
            return _mapperProduct.MapperToDTO(objProduct);
        }

        public void Remove(ProductDTO obj)
        {
            var objProduct = _mapperProduct.MapperToEntity(obj);
            _serviceProduct.Remove(objProduct);
        }

        public void Update(ProductDTO obj)
        {
            var objProduct = _mapperProduct.MapperToEntity(obj);
            _serviceProduct.Update(objProduct);
        }
    }
}
