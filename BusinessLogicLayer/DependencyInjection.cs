using eCommerce.ordersMicroservice.BusinessLogicLayer.Mappers;
using eCommerce.ordersMicroservice.BusinessLogicLayer.Services;
using eCommerce.OrdersMicroservice.BusinessLogicLayer.ServiceContracts;
using eCommerce.OrdersMicroservice.BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.OrdersMicroservice.BusinessLogicLayer;

    public static class DependencyInjection
    {

    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddValidatorsFromAssemblyContaining<OrderAddRequestValidator>();
        services.AddAutoMapper(typeof(OrderAddRequestToOrderMappingProfile).Assembly);

        services.AddScoped<IOrdersService,OrdersService>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = $"{configuration["REDIS_HOST"]}:{configuration["REDIS_PORT"]}";
        });


        return services;
    }

}

