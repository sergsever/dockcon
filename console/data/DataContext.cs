using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace console.data
{
	public class DataContext : DbContext
    {
		public DataContext() : base()
		{
			Console.WriteLine("dbcontext initialize.");
		}

		public void Init()
		{
			//			Database.in
			Console.WriteLine("Init,migrations\n");
			var migrator = Database.GetService<IMigrator>();
			migrator.Migrate();
			

		}

		override protected  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string conn = "";
			if (!optionsBuilder.IsConfigured) {
				//IConfiguration conf = new ConfigurationBuilder().AddJsonFile( Directory.GetCurrentDirectory() + @"\appsettings.json", optional: false, reloadOnChange: false).Build();
				//var conns = conf.GetSection("ConnectionStrings")["postgresql"];
				if (System.Configuration.ConfigurationManager.AppSettings["db"] == "mssql")
				{
					conn = System.Configuration.ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;   //ConnectionStrings["postgres"];
					optionsBuilder.UseSqlServer(conn);
				}
				else
				{
					conn = System.Configuration.ConfigurationManager.ConnectionStrings["postgres"].ConnectionString;   

					optionsBuilder.UseNpgsql(conn);
				}
			}

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Item>().HasKey(x => x.Id);
		}
		public DbSet<Item> Items { get; set; }

	}
}
