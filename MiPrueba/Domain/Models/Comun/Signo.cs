using System.ComponentModel.DataAnnotations;

namespace ByblosMiPH.API.Domain.Models
{
	public class Signo : DatosBase
	{
		[Key]
		public int SignoId { get; set; }
		[MaxLength(10)]
		public string Código { get; set; }

		[MaxLength(50)]
		public string Nombre { get; set; }


	}
}
