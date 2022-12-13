using AutoMapper;
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
        private IMapper _mapper;

        #region Constructor

        public MapperProduct()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });
            _mapper = config.CreateMapper();
        }

        #endregion

        #region Properties

        List<ProductDTO> productDTOs = new List<ProductDTO>();

        #endregion

        #region Methods

        public Product MapperToEntity(ProductDTO productDTO)
        {
            return _mapper.Map<Product>(productDTO);
        }

        public IEnumerable<ProductDTO> MapperListProducts(IEnumerable<Product> products)
        {
            foreach (var item in products)
            {
                productDTOs.Add(_mapper.Map<ProductDTO>(item));
            }

            return productDTOs;
        }

        public ProductDTO MapperToDTO(Product product)
        {
            return _mapper.Map<ProductDTO>(product);
        }


        #endregion
    }
}
