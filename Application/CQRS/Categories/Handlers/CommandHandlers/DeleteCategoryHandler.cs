﻿using Application.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Responses;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using Domain.Entites;
using MediatR;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Categories.Handlers.CommandHandlers;

public class DeleteCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryRequest, ResponseModel<DeleteCategoryResponse>>
{
	private readonly IUnitOfWork _unitOfWork = unitOfWork;
	public async Task<ResponseModel<DeleteCategoryResponse>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
	{
		bool isTrue = await _unitOfWork.CategoryRepository.Remove(request.Id, 0);

		if (!isTrue)
		{
			throw new NotFoundException(typeof(Category), request.Id);
		}

		return new ResponseModel<DeleteCategoryResponse>
		{
			Data = new DeleteCategoryResponse { Message = "Deleted Successfully!" },
			Errors = [],
			IsSuccess = true
		};
	}
}