using ByblosMiPH.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace ByblosMiPH.API.Configuration
{
	public class BancoConfiguration : IEntityTypeConfiguration<Banco>
	{
		public void Configure(EntityTypeBuilder<Banco> builder)
		{
			// Validación sugerida por Visual Studio
			if (builder == null)
				return;

			builder.ToTable("Bancos");
			//builder.Property(s => s.Age)
			//    .IsRequired(false);
			//builder.Property(s => s.IsRegularStudent)
			//    .HasDefaultValue(true);


			builder.HasData
			(
				new 
				{
					BancoId = 1,
					Código = "BG",
					Nombre = "Banco General",
					FechaCreación = DateTime.Now,
					FechaActualización = DateTime.Now,
					EstadoId = 1
				},
				new
				{
					BancoId = 2,
					Código = "BNP",
					Nombre = "Banco Nacional de Panamá",
					FechaCreación = DateTime.Now,
					FechaActualización = DateTime.Now,
					EstadoId = 1
				},
				new
				{
					BancoId = 3,
					Código = "CA",
					Nombre = "Caja de Ahorros",
					FechaCreación = DateTime.Now,
					FechaActualización = DateTime.Now,
					EstadoId = 1
				}
			);
		}
	}
}
