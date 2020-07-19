using ByblosMiPH.API.Domain.Models;
using ByblosMiPH.API.Domain.Repositories;
using ByblosMiPH.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ByblosMiPH.API.Persistence.Repositories
{
	public class BancoRepository : BaseRepository, IBancoRepository
	{
		MiPruebaDbContext _dbContext;

		public BancoRepository(MiPruebaDbContext context) : base(context)
		{
			_dbContext = context;
		}

		public async Task<IEnumerable<Banco>> ListAsync()
		{
			return await _dbContext.Bancos.ToListAsync();
		}

		public async Task AddAsync(Banco banco)
		{
			await _dbContext.Bancos.AddAsync(banco);
		}

		public async Task<Banco> FindByIdAsync(int bancoId)
		{
			return await _dbContext.Bancos.FindAsync(bancoId);
		}

		public void Update(Banco banco)
		{
			_dbContext.Bancos.Update(banco);
		}

		public void Remove(Banco banco)
		{
			_dbContext.Bancos.Remove(banco);
		}

	}
}
