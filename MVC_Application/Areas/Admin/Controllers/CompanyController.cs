using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Application.Database;
using MVC_Application.Models;
using MVC_Application.Repository.Interfaces;
using MVC_Application.Untility;
using System.Data;

namespace MVC_Application.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class CompanyController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext applicationDbContext;
		public CompanyController(IUnitOfWork unitOfWork,ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext= applicationDbContext;
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			return View();
		}

		//GET
		public IActionResult Upsert(int? id)
		{
			Company company = new();

			if (id == null || id == 0)
			{
				return View(company);
			}
			else
			{
				company = _unitOfWork.CompanyRepository.GetFirstOrDefault(u => u.Id == id);
				return View(company);
			}
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Upsert(Company obj, IFormFile? file)
		{

			if (ModelState.IsValid)
			{

				if (obj.Id == 0)
				{
					_unitOfWork.CompanyRepository.Add(obj);
					TempData["success"] = "Company created successfully";
				}
				else
				{
					_unitOfWork.CompanyRepository.Update(obj);
					TempData["success"] = "Company updated successfully";
				}
				_unitOfWork.Save();

				return RedirectToAction("Index");
			}
			return View(obj);
		}



		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			var companyList = _unitOfWork.CompanyRepository.GetAll();
			return Json(new { data = companyList });
		}

		//POST
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var obj = _unitOfWork.CompanyRepository.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}
			_unitOfWork.CompanyRepository.Remove(obj);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete Successful" });

		}
		#endregion
	}
}