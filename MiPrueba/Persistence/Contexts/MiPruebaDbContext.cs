using ByblosMiPH.API.Configuration;
using ByblosMiPH.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ByblosMiPH.API.Persistence.Contexts
{
	public class MiPruebaDbContext : DbContext
	{


		/// <summary>
		/// Comunes
		/// </summary>
		/// 

		public DbSet<Estado> Estados { get; set; }

		/// <summary>
		/// Banco
		/// </summary>
		/// 
		public DbSet<Banco> Bancos { get; set; }




		public MiPruebaDbContext()
		{
		}

		public MiPruebaDbContext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			// Validación sugerida por Visual Studio
			if (modelBuilder == null)
				return;

			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new EstadoConfiguration());

			modelBuilder.ApplyConfiguration(new BancoConfiguration());

		}



		public override int SaveChanges()
		{
			var entries = ChangeTracker
				.Entries()
				.Where(e => e.Entity is DatosBase && (
						e.State == EntityState.Added
						|| e.State == EntityState.Modified));

			foreach (var entityEntry in entries)
			{
				((DatosBase)entityEntry.Entity).FechaActualización = DateTime.Now;

				if (entityEntry.State == EntityState.Added)
				{
					((DatosBase)entityEntry.Entity).FechaCreación = DateTime.Now;
				}
			}

			return base.SaveChanges();
		}

	}

}
