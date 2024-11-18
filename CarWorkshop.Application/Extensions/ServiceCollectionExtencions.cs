using CarWorkshop.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtencions
    {
        public static void AddAplication(this IServiceCollection services)
        {
            
            services.AddScoped<ICarWorkshopService, CarWorkshopService>();

        }
    }
}
