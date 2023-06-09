using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
using System.Text;
using System.Threading.Tasks;
using HeseTazegi.Application.Interfaces;
using HeseTazegi.Application.Implementations;

namespace HeseTazegi.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<ICurrentUserService, FakeCurrentUserService>();
            services.AddScoped<IFoodRecommederService, FakeFoodRecommenderService>();

        }
    }
}
