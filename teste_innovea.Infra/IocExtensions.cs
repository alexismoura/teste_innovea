using teste_innovea.Data;
using teste_innovea.Data.Repositories;
using teste_innovea.Service._Ports;
using teste_innovea.Service.Containers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace teste_innovea.Service.Infra
{
    public static class IocExtensions
    {
        public static IServiceCollection AddPersistenceAdapters(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            #region DbContext Entity
            services.AddDbContext<teste_innoveaDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Repositorios Entity
            //Repositórios
            services.AddScoped<ISourceRepository, SourceRepository>();
            services.AddScoped<IRootRepository, RootRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            #endregion

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Registre novos serviços da camada de aplicação aqui:
            services.AddScoped<IArticleService, ArticleService>();
            return services;
        }
    }
}
