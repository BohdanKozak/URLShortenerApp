using Microsoft.AspNetCore.Mvc;
using URLShortener.DataAccess.Repository.IRepository;
using URLShortener.Models;

namespace URLShortener.Controllers
{

    public class URLItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public URLItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<UrlItem> UrlItems = _unitOfWork.UrlItem.GetAll().ToList();
            return View(UrlItems);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UrlItem obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.UrlItem.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "UrlItem created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
