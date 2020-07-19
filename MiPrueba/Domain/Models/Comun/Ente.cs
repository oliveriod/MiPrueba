using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByblosMiPH.API.Domain.Models
{
	public class Ente
	{
		[Key]
		public int EnteId { get; set; }
		[MaxLength(150)]
		public string Nombre { get; set; }
		[MaxLength(50)]
		public string Apellido { get; set; }


		public Sexo Sexo { get; set; }
		public DateTime? FechaNacimiento { get; set; }


		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime FechaCreación { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime FechaActualización { get; set; }

	}
}
