using DAL.SqlServer.Context;
using DAL.SqlServer.Infrastructure;
using Repository.Common;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.UnitOfWork;

public class SqlUnitOfWork(string connectionString, AppDbContext context) : IUnitOfWork
{
	private readonly string _connectionString = connectionString;
	private readonly AppDbContext _context = context;

	public SqlCategoryRepository _sqlCategoryRepository;
	public SqlProductRepository _sqlProductRepository;
	public SqlUserRepository _sqlUserRepository;

	public ICategoryRepository CategoryRepository => _sqlCategoryRepository ?? new SqlCategoryRepository(_connectionString, _context);
	public IProductRepository ProductRepository => _sqlProductRepository ?? new SqlProductRepository(_connectionString, _context);
	public IUserRepository UserRepository => _sqlUserRepository ?? new SqlUserRepository(_context);

	public async Task<int> SaveChanges()
	{
		return await _context.SaveChangesAsync();
	}
}