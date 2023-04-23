using MVC_Application.Models;

namespace MVC_Application.Repository.Interfaces
{
	public interface IOrderHeaderRepository
	: IRepository<OrderHeader>
	{
		void Update(OrderHeader obj);
		void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
		void UpdateStripePaymentID(int id, string sessionId, string paymentItentId);
	}
}
