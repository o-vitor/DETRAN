using Detran.CNH.Application.Contract;
using Detran.CNH.Application.Service;
using Detran.CNH.Domain.Contract.Repository;
using Detran.CNH.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // DB Context

            services.AddDbContext<DetranCNHDbContext>(options =>
                       options.UseSqlServer(configuration.GetConnectionString("DetranCNHDbContextConnectionString")));
      

            // Repository

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<ICondutorRepository, CondutorRepository>();
            services.AddScoped<IVeiculoCompraVendaRepository, VeiculoCompraVendaRepository>(); 
             

            // Services
            services.AddScoped<IJWTTokenService, JWTTokenService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<ICondutorService, CondutorService>();
            services.AddScoped<IVeiculoCompraVendaService, VeiculoCompraVendaService>();
        }
    }
}
