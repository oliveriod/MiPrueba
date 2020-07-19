using ByblosMiPH.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ByblosMiPH.API.Domain.Repositories
{
	public interface IBancoRepository
	{
		Task<IEnumerable<Banco>> ListAsync();
		Task AddAsync(Banco banco);
		Task<Banco> FindByIdAsync(int bancoId);
		void Update(Banco banco);
		void Remove(Banco banco);
	}
}
