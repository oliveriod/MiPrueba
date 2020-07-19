using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByblosMiPH.API.Domain.Models
{
	public class Sexo
	{
		[Key]
		public int SexoId { get; set; }
		[MaxLength(1)]
		public string Código { get; set; }
		[MaxLength(50)]
		public string Nombre { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime FechaCreación { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime FechaActualización { get; set; }

	}
}
