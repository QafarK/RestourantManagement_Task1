using Application.CQRS.Categories.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Categories.Commands.Requests;

public record struct DeleteCategoryRequest : IRequest<ResponseModel<DeleteCategoryResponse>>
{
	public int Id { get; set; }
}