using ProductManager.Domain.Core.Interfaces.Repositories;
using ProductManager.Domain.Core.Services;
using ProductManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Domain.Services.Services
{
    public class ServiceProduct : ServiceBase<Product>, IServiceProduct
    {
        public readonly IRepositoryProduct _repositoryProduct;

        public ServiceProduct(IRepositoryProduct RepositoryProduct)
            : base(RepositoryProduct)
        {
            _repositoryProduct = RepositoryProduct;
        }
    }
}
