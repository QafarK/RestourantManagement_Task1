using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application;
public static class DependencyInjections
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		//#region AutoMapper
		//var mapperConfig = new MapperConfiguration(mc =>
		//{
		//	mc.AddProfile(new MappingProfile());
		//});

		//IMapper mapper = mapperConfig.CreateMapper();
		//services.AddSingleton(mapper);
		//#endregion

		//services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


		//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

		services.AddMediatR(Assembly.GetExecutingAssembly());
		return services;
	}	
}