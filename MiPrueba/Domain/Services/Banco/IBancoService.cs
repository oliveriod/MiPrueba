using ByblosMiPH.API.Domain.Models;
using ByblosMiPH.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ByblosMiPH.API.Domain.Services
{
	public interface IBancoService
	{
		Task<IEnumerable<Banco>> ListAsync();
		Task<BancoResponse> SaveAsync(Banco banco);
		Task<BancoResponse> UpdateAsync(int bancoId, Banco banco);
		Task<BancoResponse> DeleteAsync(int bancoId);
	}
}

