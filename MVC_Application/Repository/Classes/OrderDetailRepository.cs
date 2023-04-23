using MVC_Application.Database;
using MVC_Application.Models;
using MVC_Application.Repository.Interfaces;
namespace MVC_Application.Repository.Classes
{
	 
		public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
		{
			private ApplicationDbContext _db;

			public OrderDetailRepository(ApplicationDbContext db) : base(db)
			{
				_db = db;
			}

			public void Update(OrderDetail obj)
			{
				_db.OrderDetails.Update(obj);
			}
	    }
}
