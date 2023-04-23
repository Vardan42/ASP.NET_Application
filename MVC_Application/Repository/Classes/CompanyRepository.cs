using MVC_Application.Database;
using MVC_Application.Models;
using MVC_Application.Repository.Interfaces;

namespace MVC_Application.Repository.Classes
{
	public class CompanyRepository
: Repository<Company>, ICompanyRepository
	{
		private ApplicationDbContext _db;

		public CompanyRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}


		public void Update(Company obj)
		{
			_db.Companies.Update(obj);
		}
	}
}
