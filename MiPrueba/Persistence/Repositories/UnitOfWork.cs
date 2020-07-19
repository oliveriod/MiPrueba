using ByblosMiPH.API.Domain.Repositories;
using ByblosMiPH.API.Persistence.Contexts;
using System.Threading.Tasks;

namespace ByblosMiPH.API.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MiPruebaDbContext _context;

		public UnitOfWork(MiPruebaDbContext context)
		{
			_context = context;
		}

		public async Task CompleteAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
