using System;

namespace ProductManager.Domain.Models
{
    public class Product : Base
    {
        public string Description { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiringDate { get; set; }
        public int ProviderId { get; set; }
        public string ProviderDescription { get; set; }
        public string ProviderCnpj { get; set; }
    }
}
