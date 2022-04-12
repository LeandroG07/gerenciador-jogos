using AutoMapper;
using GerenciamentoJogos.Data.Context;
using GerenciamentoJogos.Data.Infra.Repositories;
using GerenciamentoJogos.Data.Provider;
using GerenciamentoJogos.Data.Repositories;
using GerenciamentoJogos.Domain.Repositories;
using GerenciamentoJogos.Domain.Services;
using GerenciamentoJogos.Domain.Services.Validation;
using GerenciamentoJogos.Service;
using GerenciamentoJogos.Service.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GerenciamentoJogos.Crosscutting.Ioc
{
    public static class Bootstrapper
    {

        public static IServiceCollection RegisterDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            // Service
            services.AddScoped<IServiceValidate, ServiceValidate>();
            services.AddScoped<IAmigoService, AmigoService>();
            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();

            // Data
            services.AddScoped<IDbConnectionProvider, SqlConnectionProvider>();
            services.AddSingleton(_ => new GerenciamentoJogosDbContext(new SqlConnectionProvider(), configuration.GetConnectionString("SqlGerenciamentoJogos")));
            services.AddScoped<IAmigoRepository, AmigoRepository>();
            services.AddScoped<IJogoRepository, JogoRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

            return services;
        }

        public static IServiceCollection RegisterAutoMapper(IServiceCollection services)
        {            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();                
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

    }
}
