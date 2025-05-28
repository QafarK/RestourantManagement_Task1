using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories;

public interface IUserRepository
{
	Task RegisterAsync(User user);
	void Update(User user);
	Task Remove(int id);
	IQueryable<User> GetAll();
	Task<User> GetByIdAsync(int id);
	Task<User> GetByEmailAsync(string email);
}