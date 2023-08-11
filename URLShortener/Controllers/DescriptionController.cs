using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;

namespace URLShortener.Controllers
{
    public class DescriptionController : Controller
    {
        static string fileName = "Description.txt";
        static string filePath = Path.Combine(Environment.CurrentDirectory, fileName);


        private DescriptionModel? _description;

        public DescriptionController()
        {
            _description = DescriptionModel.LoadFromFile(filePath);
        }

        public IActionResult Index()
        {
            return View(_description);
        }


        public IActionResult Edit()
        {
            return View(_description);
        }

        [HttpPost]
        public IActionResult Edit(DescriptionModel newText)
        {


            if (newText != null)
            {
                _description.Text = newText.Text;
                _description.SaveToFile(filePath);
                TempData["success"] = "Description updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}