using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Categories.Queries.Responses;

public sealed class GetByIdCategoryResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public DateTime CreatedDate { get; set; }
}