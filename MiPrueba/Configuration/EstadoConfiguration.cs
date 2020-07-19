using ByblosMiPH.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ByblosMiPH.API.Configuration
{
	public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
	{
		public void Configure(EntityTypeBuilder<Estado> builder)
		{

			// Validación sugerida por Visual Studio
			if (builder == null)
				return;

			builder.ToTable("Estados");


			builder.HasData
			(
				new Estado
				{
					EstadoId = -1,
					Código = "INAC",
					Nombre = "Inactivo",
					FechaCreación = DateTime.Now,
					FechaActualización = DateTime.Now,
				},
				new Estado
				{
					EstadoId = 1,
					Código = "ACTI",
					Nombre = "Activo",
					FechaCreación = DateTime.Now,
					FechaActualización = DateTime.Now,
				}
			);
		}
	}
}
