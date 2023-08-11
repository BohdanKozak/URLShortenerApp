using Newtonsoft.Json;

namespace UrlShortener.Models
{
    public class DescriptionModel
    {
        public DescriptionModel()
        {

        }
        public DescriptionModel(string text, string title, string author)
        {
            Text = text;
            Title = title;
            Author = author;
        }

        public string Text { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public void SaveToFile(string filePath)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, json);
        }

        public static DescriptionModel? LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<DescriptionModel>(json);
            }
            return null;
        }
    }

}
