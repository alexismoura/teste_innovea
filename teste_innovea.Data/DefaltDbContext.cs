using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace teste_innovea.Data
{
    public class DefaltDbContext : DbContext
    {
		private readonly IHostingEnvironment _env;
		private IConfiguration _config;
		private string _connectionString;

		public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(
															builder => {
																builder.SetMinimumLevel(LogLevel.Debug);
															});

		#region Costrutores
		public DefaltDbContext(IHostingEnvironment env, IConfiguration config, string connectionString)
		{
			_env = env;
			_config = config;
			_connectionString = connectionString;
		}
		#endregion

		#region Metodos Protected
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var config = new ConfigurationBuilder()
			   .SetBasePath(_env.ContentRootPath)
			   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			   .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
			   .AddEnvironmentVariables();

			// define the database to use
			optionsBuilder.UseLoggerFactory(loggerFactory)
				.UseMySql(config.Build().GetConnectionString(_connectionString));
		}
		#endregion
	}
}
