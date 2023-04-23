using MVC_Application.Database;
using MVC_Application.Models;
using MVC_Application.Repository.Interfaces;

namespace MVC_Application.Repository.Classes
{
	public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
	{
		private ApplicationDbContext _db;

		public ShoppingCartRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public int DecrementCount(ShoppingCart shoppingCart, int count)
		{
			shoppingCart.Count -= count;
			return shoppingCart.Count;
		}

		public int IncrementCount(ShoppingCart shoppingCart, int count)
		{
			shoppingCart.Count += count;
			return shoppingCart.Count;
		}
	}
}
