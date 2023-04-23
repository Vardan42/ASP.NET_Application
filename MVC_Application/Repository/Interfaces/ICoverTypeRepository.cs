using MVC_Application.Models;

namespace MVC_Application.Repository.Interfaces
{
	public interface ICoverTypeRepository
	 : IRepository<CoverType>
	{
		void Update(CoverType obj);
	}
}
