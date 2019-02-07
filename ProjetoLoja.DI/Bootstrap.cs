using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoLoja.Data;
using System;

namespace ProjetoLoja.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<ProjetoLojaDBContext>(options =>
                options.UseSqlServer(connection));


        }
    }
}
