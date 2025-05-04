using Domain.Entites;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories;

public interface IProductRepository 
{
	Task AddAsync(Product product);
	Task Update(Product product);
	Task<bool> Remove(int id, int deletedBy);
	IQueryable<Product> GetAll();
	Task<Product> GetByIdAsync(int id);
	Task<IEnumerable<Product>> GetByNameAsync(string name);
}
