using ProductManager.Application.DTO.DTO;
using ProductManager.Application.Interfaces;
using ProductManager.Domain.Core.Interfaces.Services;
using ProductManager.Domain.Filters;
using ProductManager.Domain.Models;
using ProductManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            if (obj.ExpiringDate < obj.ManufacturingDate) throw new ArgumentException("ExpiringData must be greater than ManufacturingDate");
            var objProduct = _mapperProduct.MapperToEntity(obj);
            _serviceProduct.Add(objProduct);
        }

        public void Dispose()
        {
            _serviceProduct.Dispose();
        }

        public IEnumerable<ProductDTO> GetAll(PaginationModel pagination, Expression<Func<Product, bool>> filter)
        {
            var objProducts = _serviceProduct.GetAll(pagination, filter);
            return _mapperProduct.MapperListProducts(objProducts);
        }

        public ProductDTO GetById(int id)
        {
            return _mapperProduct.MapperToDTO(_serviceProduct.GetById(id));
        }

        public void Remove(ProductDTO obj)
        {
            var objProduct = _mapperProduct.MapperToEntity(obj);
            _serviceProduct.Remove(objProduct);
        }

        public void Update(ProductDTO obj)
        {
            if (obj.ExpiringDate < obj.ManufacturingDate) throw new ArgumentException("ExpiringData must be greater than ManufacturingDate");

            var objProduct = _mapperProduct.MapperToEntity(obj);
            _serviceProduct.Update(objProduct);
        }
    }
}
