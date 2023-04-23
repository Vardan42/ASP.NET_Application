using MVC_Application.Models;

namespace MVC_Application.Repository.Interfaces
{
	public interface IShoppingCartRepository
 : IRepository<ShoppingCart>
	{
		int IncrementCount(ShoppingCart shoppingCart, int count);
		int DecrementCount(ShoppingCart shoppingCart, int count);
	}
}
