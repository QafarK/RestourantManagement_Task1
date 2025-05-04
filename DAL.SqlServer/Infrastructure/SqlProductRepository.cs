using DAL.SqlServer.Context;
using Dapper;
using Domain.Entites;
using Domain.Entities;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.Infrastructure;

public class SqlProductRepository : BaseSqlRepository, IProductRepository
{
	private readonly AppDbContext _context;

	public SqlProductRepository(string connectionString, AppDbContext context) : base(connectionString)
	{
		_context = context;
	}

	public async Task AddAsync(Product product)
	{
		var sql = @"INSERT INTO PRODUCTS([Name],[CreatedBy])
                    VALUES(@Name , @CreatedBy); SELECT SCOPE_IDENTITY()";

		using var conn = OpenConnection();
		var generatedId = await conn.ExecuteScalarAsync<int>(sql, product);
		product.Id = generatedId;
	}

	public IQueryable<Product> GetAll()
	{
		return _context.Products.OrderByDescending(c => c.CreatedDate).Where(c => c.IsDeleted == false);
	}

	public async Task<Product> GetByIdAsync(int id)
	{
		var sql = @"SELECT c.*
                    FROM PRODUCTS c
                    WHERE c.Id=@id AND c.IsDeleted=0";

		using var conn = OpenConnection();

		return await conn.QueryFirstOrDefaultAsync<Product>(sql, new { id });
	}

	public async Task<IEnumerable<Product>> GetByNameAsync(string name)
	{
		var sql = @"DECLARE @searchText NVARCHAR(max)
                    SET @searchText = '%'+ @name + '%'
                    SELECT c.* 
                    FROM Products c
                    WHERE c.[Name] Like @searchText and c.IsDeleted=0";

		using var conn = OpenConnection();
		return await conn.QueryAsync<Product>(sql, name);
	}

	public async Task<bool> Remove(int id, int deletedBy)
	{
		var checkSql = "SELECT Id FROM Products WHERE Id=@id AND IsDeleted=0";

		var sql = @"UPDATE Products
                    SET IsDeleted=1,
                    DeletedBy= @deletedBy,
                    DeletedDate = GETDATE()
                    Where Id=@id";

		using var conn = OpenConnection();
		using var transaction = conn.BeginTransaction();

		var productId = await conn.ExecuteScalarAsync<int?>(checkSql, new { id }, transaction);

		if (!productId.HasValue)
			return false;

		var affectedRow = await conn.ExecuteAsync(sql, new { id, deletedBy }, transaction);

		transaction.Commit();

		return affectedRow > 0;
	}

	public async Task Update(Product product)
	{
		var sql = @"UPDATE Products
                    SET Name = @Name,
                    UpdatedBy= @UpdatedBy,
                    UpdatedDate = GETDATE()
                    WHERE Id = @Id";

		using var conn = OpenConnection();
		await conn.QueryAsync<Product>(sql, product);
	}
}
