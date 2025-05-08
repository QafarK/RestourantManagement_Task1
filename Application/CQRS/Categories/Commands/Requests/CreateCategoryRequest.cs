using Application.CQRS.Categories.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Categories.Commands.Requests;

public class CreateCategoryRequest : IRequest<ResponseModel<CreateCategoryResponse>>
{
	public string Name { get; set; }
}
