using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Application.Models;
using MVC_Application.Repository.Interfaces;
using MVC_Application.Untility;
using System.Diagnostics;
using System.Security.Claims;

namespace MVC_Application.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork _unitOfWork;

		public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
		{
			_logger = logger;
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			IEnumerable<Product> productList = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category,CoverType");

			return View(productList);
		}

		public IActionResult Details(int productId)
		{
			ShoppingCart cartObj = new()
			{
				Count = 1,
				ProductId = productId,
				Product = _unitOfWork.ProductRepository.GetFirstOrDefault(u => u.Id == productId, includeProperties: "Category,CoverType"),
			};

			return View(cartObj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public IActionResult Details(ShoppingCart shoppingCart)
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			shoppingCart.ApplicationUserId = claim.Value;

			ShoppingCart cartFromDb = _unitOfWork.ShoppingCartRepository.GetFirstOrDefault(
				u => u.ApplicationUserId == claim.Value && u.ProductId == shoppingCart.ProductId);


			if (cartFromDb == null)
			{

				_unitOfWork.ShoppingCartRepository.Add(shoppingCart);
				_unitOfWork.Save();
				HttpContext.Session.SetInt32(SD.SessionCart,
					_unitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count);
			}
			else
			{
				_unitOfWork.ShoppingCartRepository.IncrementCount(cartFromDb, shoppingCart.Count);
				_unitOfWork.Save();
			}


			return RedirectToAction(nameof(Index));
		}

 

	}
}
