using Application.CQRS.Categories.Commands.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Categories.Validator;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
	public CreateCategoryValidator()
	{
		RuleFor(c => c.Name)
			.NotEmpty()
			.MaximumLength(255);
	}
}