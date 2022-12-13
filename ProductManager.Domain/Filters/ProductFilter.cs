using ProductManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Filters
{
    public class ProductFilter
    {
        public string Description { get; set; } = string.Empty;
        public DateTime MinManufacturingDate { get; set; } = DateTime.MinValue;
        public DateTime MaxManufacturingDate { get; set; } = DateTime.MaxValue;
        public DateTime MinExpiringDate { get; set; } = DateTime.MinValue;
        public DateTime MaxExpiringDate { get; set; } = DateTime.MaxValue;
        public string ProviderDescription { get; set; } = string.Empty;
        public string ProviderCnpj { get; set; } = string.Empty;
    
        public Expression<Func<Product, bool>> SetFilter()
        {
            Expression<Func<Product, bool>> func =
                p => p.Description.Contains(Description)
                    &p.ManufacturingDate > MinManufacturingDate
                    & p.ManufacturingDate < MaxManufacturingDate
                    & p.ExpiringDate > MinExpiringDate
                    & p.ExpiringDate < MaxExpiringDate
                    & p.ProviderDescription.Contains(ProviderDescription)
                    & p.ProviderCnpj.Contains(ProviderCnpj);

            return func;
        }
    }

}
