using MVC_Application.Models;

namespace MVC_Application.Repository.Interfaces
{
	public interface IOrderDetailRepository
	: IRepository<OrderDetail>
	{
		void Update(OrderDetail obj);
	}
}
