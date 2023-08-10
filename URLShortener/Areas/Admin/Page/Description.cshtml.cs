using Microsoft.AspNetCore.Mvc.RazorPages;

namespace URLShortener.Areas.Admin.Page
{
    public class DescriptionModel : PageModel
    {
        static string fileName = "Description.txt";
        public string? Description { get; set; }
        string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
        public void OnGet()
        {
            Description = string.Empty;
        }
    }
}
