using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByblosMiPH.API.Domain.Models
{ 
	public class Banco : DatosBase
	{
		[Key]
		public int BancoId { get; set; }

		[MaxLength(50)]
		public string Código { get; set; }

		[MaxLength(150)]
		public string Nombre { get; set; }




		public Estado Estado { get; set; }

	}
}
