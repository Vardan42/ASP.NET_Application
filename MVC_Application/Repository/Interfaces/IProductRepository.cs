using MVC_Application.Models;

namespace MVC_Application.Repository.Interfaces
{
	public interface IProductRepository
: IRepository<Product>
	{
		void Update(Product obj);
	}
}
