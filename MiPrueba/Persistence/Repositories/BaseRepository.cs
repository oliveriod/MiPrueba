using ByblosMiPH.API.Persistence.Contexts;

namespace ByblosMiPH.API.Persistence.Repositories
{

	public abstract class BaseRepository
	{
		private protected readonly MiPruebaDbContext _context;

		public BaseRepository(MiPruebaDbContext context)
		{
			_context = context;
		}
	}
}
