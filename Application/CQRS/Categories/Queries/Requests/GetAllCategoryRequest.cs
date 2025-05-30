﻿using Application.CQRS.Categories.Queries.Responses;
using Common.GlobalResopnses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Categories.Queries.Requests;

public sealed class GetAllCategoryRequest : IRequest<ResponseModelPagination<GetAllCategoryResponse>>
{
	public int Limit { get; set; } = 10;
	public int Page { get; set; } = 1;
}