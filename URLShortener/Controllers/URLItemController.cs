using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shortid;
using shortid.Configuration;
using URLShortener.DataAccess.Repository.IRepository;
using URLShortener.Models;
using URLShortener.Utility;


namespace URLShortener.Controllers
{

    public class URLItemController : Controller

    {
        UserManager<IdentityUser> UserManager;
        private readonly IUnitOfWork _unitOfWork;
        private const string ServiceUrl = "http://localhost:7254";
        public URLItemController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            UserManager = userManager;
        }

        public IActionResult Index()
        {
            List<UrlItem> UrlItems = _unitOfWork.UrlItem.GetAll().ToList();
            return View(UrlItems);
        }

        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_USER)]
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


            string? longUrl = obj.Url;
            var shortenedUrlCollection = _unitOfWork.UrlItem.GetAll();
            var shortenedUrl = shortenedUrlCollection.FirstOrDefault(x => x.Url == longUrl);
            if (shortenedUrl == null)
            {
                var shortCode = ShortId.Generate(new GenerationOptions(length: 9));
                obj.ShortedUrl = $"{ServiceUrl}?u={shortCode}";
                obj.ShortCode = shortCode;
                obj.CreatedBy = UserManager.GetUserName(User);
            }
            else
            {
                ModelState.AddModelError("url", "The url is already Exist");
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

        public IActionResult DeleteAll()
        {

            List<UrlItem> UrlItems = _unitOfWork.UrlItem.GetAll().ToList();

            foreach (var urlItem in UrlItems)
            {

                _unitOfWork.UrlItem.Remove(urlItem);


            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
