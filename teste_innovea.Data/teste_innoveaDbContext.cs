using System;
using System.Collections.Generic;
using System.Text;
using teste_innovea.Data.Mapping;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace teste_innovea.Data
{
    public class teste_innoveaDbContext : DefaltDbContext
    {
        private readonly IHostingEnvironment _env;
        private IConfiguration _config;
        private string _connectionString;

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(
                                                                    builder => {
                                                                        builder.SetMinimumLevel(LogLevel.Debug);
                                                                    });

        #region Costrutores
        public teste_innoveaDbContext(IHostingEnvironment env, IConfiguration config) :
               base(env, config, "DefaultConnection")
        { 

        }
        #endregion

        #region Metodos Protected

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //MAPEAMENTO
            modelBuilder.ApplyConfiguration(new SourceMap());
            modelBuilder.ApplyConfiguration(new RootMap());
            modelBuilder.ApplyConfiguration(new ArticleMap());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
