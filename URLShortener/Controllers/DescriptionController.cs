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


            //_description = DescriptionModel.LoadFromFile(Path.Combine(filePath, fileName));

        }

        public IActionResult Index()
        {
            var editableContent = DescriptionModel.LoadFromFile(filePath);

            return View(editableContent);
        }



    }
}