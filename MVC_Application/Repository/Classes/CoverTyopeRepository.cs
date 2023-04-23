using MVC_Application.Database;
using MVC_Application.Models;
using MVC_Application.Repository.Interfaces;

namespace MVC_Application.Repository.Classes
{
	public class CoverTypeRepository
: Repository<CoverType>, ICoverTypeRepository
	{
		private ApplicationDbContext _db;

		public CoverTypeRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}


		public void Update(CoverType obj)
		{
			_db.CoverTypes.Update(obj);
		}
	}
}
