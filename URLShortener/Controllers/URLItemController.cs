using Microsoft.AspNetCore.Mvc;

namespace URLShortener.Controllers
{

    public class URLItemController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
