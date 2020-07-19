
using ByblosMiPH.API.Domain.Models;

namespace ByblosMiPH.API.Domain.Services.Communication
{
	public class BancoResponse : BaseResponse
	{
		public Banco Banco { get; private set; }

		private BancoResponse(bool success, string message, Banco banco) : base(success, message)
		{
			Banco = banco;
		}

		/// <summary>
		/// Creates a success response.
		/// </summary>
		/// <param name="banco">Saved banco.</param>
		/// <returns>Response.</returns>
		public BancoResponse(Banco banco) : this(true, string.Empty, banco)
		{ }

		/// <summary>
		/// Creates am error response.
		/// </summary>
		/// <param name="message">Error message.</param>
		/// <returns>Response.</returns>
		public BancoResponse(string message) : this(false, message, null)
		{ }
	}
}
