using ProductManager.Application.DTO.DTO;
using ProductManager.Domain.Models;
using System.Collections.Generic;

namespace ProductManager.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperProduct
    {
        #region Mappers

        Product MapperToEntity(ProductDTO productDTO);

        IEnumerable<ProductDTO> MapperListProducts(IEnumerable<Product> products);

        ProductDTO MapperToDTO(Product product);

        #endregion
    }
}
