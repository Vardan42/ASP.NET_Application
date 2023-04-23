using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Application.Models;
using MVC_Application.Repository.Interfaces;
using MVC_Application.Untility;
using System.Data;

namespace MVC_Application.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class CoverTypeController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public CoverTypeController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverTypeRepository.GetAll();
			return View(objCoverTypeList);
		}
		//GET
		public IActionResult Create()
		{
			return View();
		}
		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CoverType obj)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.CoverTypeRepository.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "CoverType created successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}
		//GET
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var CoverTypeFromDbFirst = _unitOfWork.CoverTypeRepository.GetFirstOrDefault(u => u.Id == id);

			if (CoverTypeFromDbFirst == null)
			{
				return NotFound();
			}

			return View(CoverTypeFromDbFirst);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(CoverType obj)
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.CoverTypeRepository.Update(obj);
				_unitOfWork.Save();
				TempData["success"] = "CoverType updated successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var CoverTypeFromDbFirst = _unitOfWork.CoverTypeRepository.GetFirstOrDefault(u => u.Id == id);

			if (CoverTypeFromDbFirst == null)
			{
				return NotFound();
			}

			return View(CoverTypeFromDbFirst);
		}

		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _unitOfWork.CoverTypeRepository.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return NotFound();
			}

			_unitOfWork.CoverTypeRepository.Remove(obj);
			_unitOfWork.Save();
			TempData["success"] = "CoverType deleted successfully";
			return RedirectToAction("Index");

		}
	}
}