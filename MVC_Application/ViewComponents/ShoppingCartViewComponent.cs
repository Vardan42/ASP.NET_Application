using Microsoft.AspNetCore.Mvc;
using MVC_Application.Repository.Interfaces;
using MVC_Application.Untility;
using System.Security.Claims;

namespace MVC_Application.ViewComponents
{
	public class ShoppingCartViewComponent:ViewComponent
	{
		private readonly IUnitOfWork _unitOfWork;
		public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			if (claim != null)
			{
				if (HttpContext.Session.GetInt32(SD.SessionCart) != null)
				{
					return View(HttpContext.Session.GetInt32(SD.SessionCart));
				}
				else
				{
					HttpContext.Session.SetInt32(SD.SessionCart,
						_unitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count);
					return View(HttpContext.Session.GetInt32(SD.SessionCart));
				}
			}
			else
			{
				HttpContext.Session.Clear();
				return View(0);
			}
		}
	}
}
