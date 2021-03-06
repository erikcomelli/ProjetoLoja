﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoLoja.Data;
using ProjetoLoja.Interfaces;
using ProjetoLoja.Services;

namespace ProjetoLoja.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<ProjetoLojaDBContext>(options =>
                options.UseSqlServer(connection));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(CategoryService));


        }
    }
}