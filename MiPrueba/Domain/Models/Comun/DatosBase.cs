using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByblosMiPH.API.Domain.Models
{
	public class DatosBase
	{

		public DateTime FechaCreación { get; set; }
		public DateTime FechaActualización { get; set; }

	}
}
