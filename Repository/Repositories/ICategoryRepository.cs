using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories;

public interface ICategoryRepository
{
	Task AddAsync(Category category);
	Task Update(Category category);
	Task<bool> Remove(int id, int deletedBy);
	IQueryable<Category> GetAll();
	Task<Category> GetByIdAsync(int id);
	Task<IEnumerable<Category>> GetByNameAsync(string name);
}
