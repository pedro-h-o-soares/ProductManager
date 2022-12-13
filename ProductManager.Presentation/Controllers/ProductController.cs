using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.DTO.DTO;
using ProductManager.Application.Interfaces;
using ProductManager.Domain.Filters;
using ProductManager.Domain.Models;
using System;
using System.Collections.Generic;

namespace ProductManager.Presentation.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IApplicationServiceProduct _applicationServiceProduct;

        public ProductController(IApplicationServiceProduct ApplicationServiceProduct)
        {
            _applicationServiceProduct = ApplicationServiceProduct;
        }

        // GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromHeader] PaginationModel pagination, [FromHeader] ProductFilter filter)
        {
            return Ok(_applicationServiceProduct.GetAll(pagination, filter.SetFilter()));
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceProduct.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return NotFound();

                if (productDTO.ExpiringDate < productDTO.ManufacturingDate)
                {
                    return BadRequest();
                }

                _applicationServiceProduct.Add(productDTO);
                return Ok("Produto cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/product/5
        [HttpPut]
        public ActionResult Put([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return NotFound();

                if (productDTO.ExpiringDate < productDTO.ManufacturingDate)
                {
                    return BadRequest("A data de expiração deve ser maior que a de fabricação");
                }

                _applicationServiceProduct.Update(productDTO);
                return Ok("Produto atualizado com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/product/5
        [HttpDelete]
        public ActionResult Delete([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return NotFound();

                _applicationServiceProduct.Remove(productDTO);
                return Ok("Produto removido com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}