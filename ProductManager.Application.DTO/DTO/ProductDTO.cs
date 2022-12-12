using System;

namespace ProductManager.Application.DTO.DTO
{
    public  class ProductDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiringDate { get; set; }
    }
}
