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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));


        }
    }
}
