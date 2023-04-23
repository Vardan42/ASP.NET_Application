using MVC_Application.Database;
using MVC_Application.Models;
using MVC_Application.Repository.Interfaces;

namespace MVC_Application.Repository.Classes
{
	public class ApplicationUserRepository
	: Repository<ApplicationUser>, IApplicationUserRepository
	{
		private ApplicationDbContext _db;

		public ApplicationUserRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

	}
}
