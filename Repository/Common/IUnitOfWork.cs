using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
	public interface IUnitOfWork
	{
		public ICategoryRepository CategoryRepository { get; }
		public IProductRepository ProductRepository { get; }
		public IUserRepository UserRepository { get; }

		Task<int> SaveChanges();
	}
}
