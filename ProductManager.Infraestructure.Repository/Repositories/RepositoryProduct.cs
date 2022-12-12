using ProductManager.Domain.Core.Interfaces.Repositories;
using ProductManager.Domain.Models;
using ProductManager.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infraestructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        private readonly SqlContext _context;

        public RepositoryProduct(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
