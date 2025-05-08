using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.CQRS.Categories.Commands.Responses;

public record struct DeleteCategoryResponse
{
	public string Message { get; set; }
}