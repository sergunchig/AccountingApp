using AccountingApp.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp
{
    static class ServiseExtension
    {
        public static IServiceCollection AddPages(this IServiceCollection services)
        {
            services.AddTransient<CostCathegoryPage>();
            services.AddTransient<CostsPage>();
            services.AddTransient<StatisticsPage>();
            return services;
        }
        public static IServiceCollection AddWindows(this IServiceCollection services)
        {

            return services;
        }
    }
}
