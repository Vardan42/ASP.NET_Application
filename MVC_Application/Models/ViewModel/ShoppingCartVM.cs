﻿namespace MVC_Application.Models.ViewModel
{
	public class ShoppingCartVM
	{

		public IEnumerable<ShoppingCart> ListCart { get; set; }

		public OrderHeader OrderHeader { get; set; }
	}
}
