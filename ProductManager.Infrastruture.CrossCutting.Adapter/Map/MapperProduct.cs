using ProductManager.Application.DTO.DTO;
using ProductManager.Domain.Models;
using ProductManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperProduct : IMapperProduct
    {

        #region Properties

        List<ProductDTO> productDTOs = new List<ProductDTO>();

        #endregion

        #region Methods

        public Product MapperToEntity(ProductDTO productDTO)
        {
            Product product = new Product
            {
                Description = productDTO.Description,
                ExpiringDate = productDTO.ExpiringDate,
                ManufacturingDate = productDTO.ManufacturingDate,
                ProviderCnpj = productDTO.ProviderCnpj,
                ProviderDescription = productDTO.ProviderDescription
            };

            return product;
        }

        public IEnumerable<ProductDTO> MapperListProducts(IEnumerable<Product> products)
        {
            foreach (var item in products)
            {
                ProductDTO productDTO = new ProductDTO
                {
                    Description = item.Description,
                    ExpiringDate = item.ExpiringDate,
                    ManufacturingDate = item.ManufacturingDate,
                    ProviderCnpj= item.ProviderCnpj,
                    ProviderDescription = item.ProviderDescription
                };

                productDTOs.Add(productDTO);
            }

            return productDTOs;
        }

        public ProductDTO MapperToDTO(Product product)
        {

            ProductDTO productDTO = new ProductDTO
            {
                Description = product.Description,
                ExpiringDate = product.ExpiringDate,
                ManufacturingDate = product.ManufacturingDate,
                ProviderCnpj= product.ProviderCnpj,
                ProviderDescription = product.ProviderDescription
            };

            return productDTO;
        }


        #endregion
    }
}
