using Application.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Responses;
using Common.GlobalResponses.Generics;
using Domain.Entites;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Application.CQRS.Categories.Handlers.CommandHandlers;

public class CreateCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryRequest, ResponseModel<CreateCategoryResponse>>
{
	private readonly IUnitOfWork _unitOfWork = unitOfWork;

	public async Task<ResponseModel<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
	{
		Category newCategory = new()
		{
			Name = request.Name,
		};

		if (string.IsNullOrEmpty(request.Name))
		{
			return new ResponseModel<CreateCategoryResponse>
			{
				Data = null,
				Errors = ["Gonderilen melumat bosh veya null ola bilmez"],
				IsSuccess = false
			};
		}

		await _unitOfWork.CategoryRepository.AddAsync(newCategory);

		CreateCategoryResponse response = new()
		{
			Id = newCategory.Id,
			Name = request.Name,
		};

		return new ResponseModel<CreateCategoryResponse>
		{
			Data = response,
			Errors = [],
			IsSuccess = true
		};

	}
}
