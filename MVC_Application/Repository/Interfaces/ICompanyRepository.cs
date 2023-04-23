using MVC_Application.Models;

namespace MVC_Application.Repository.Interfaces
{
	public interface ICompanyRepository:IRepository<Company>
	{
		void Update(Company obj);
	}
}
