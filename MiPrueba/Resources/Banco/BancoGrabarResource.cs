using System.ComponentModel.DataAnnotations;

namespace ByblosMiPH.API.Resources
{
	public class BancoGrabarResource
	{
		[Required]
		[MaxLength(50)]
		public string Código { get; set; }
		[Required]
		[MaxLength(150)]
		public string Nombre { get; set; }
	}
}
