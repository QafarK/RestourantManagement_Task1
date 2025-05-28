using Application.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Responses;
using Application.CQRS.Users.DTOs;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<User, GetByIdDto>().ReverseMap();
		CreateMap<Command, User>().ReverseMap();
		CreateMap<User, RegisterDto>().ReverseMap();


		CreateMap<Category, CreateCategoryRequest>().ReverseMap();
		CreateMap<CreateCategoryResponse, Category>().ReverseMap();
	}
}