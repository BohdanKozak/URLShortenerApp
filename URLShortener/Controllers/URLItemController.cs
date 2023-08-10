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
            if (obj.Url != null && obj.Url.Length < 9)
            {
                ModelState.AddModelError("url", "The url is wrong");
            }
            else if (obj.Url?.Substring(0, 8) != "https://")
            {
                ModelState.AddModelError("url", "The url is wrong");
            }


            if (ModelState.IsValid)
            {

                _unitOfWork.UrlItem.Add(obj);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var url = _unitOfWork.UrlItem.Get(item => item.Id == id);
            if (url == null)
            {
                return NotFound();
            }
            _unitOfWork.UrlItem.Remove(url);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            UrlItem UrlItems = _unitOfWork.UrlItem.Get(item => item.Id == id);
            return View(UrlItems);
        }



    }
}
