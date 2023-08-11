namespace UrlShortener.Models.Tests
{
    [TestClass]
    public class DescriptionModelTest
    {

        [TestMethod]
        public void SaveToFile_FileShouldBeCreated()
        {

            var description = new DescriptionModel("Sample text", "Sample title", "Sample author");
            var filePath = "test.json";


            description.SaveToFile(filePath);


            Assert.IsTrue(File.Exists(filePath));


            File.Delete(filePath);
        }

        [TestMethod]
        public void LoadFromFile_ValidFile_ShouldLoadDescriptionModel()
        {

            var originalDescription = new DescriptionModel("Sample text", "Sample title", "Sample author");
            var filePath = "test.json";
            originalDescription.SaveToFile(filePath);


            var loadedDescription = DescriptionModel.LoadFromFile(filePath);


            Assert.IsNotNull(loadedDescription);
            Assert.AreEqual(originalDescription.Text, loadedDescription?.Text);
            Assert.AreEqual(originalDescription.Title, loadedDescription?.Title);
            Assert.AreEqual(originalDescription.Author, loadedDescription?.Author);


            File.Delete(filePath);
        }

        [TestMethod]
        public void LoadFromFile_InvalidFile_ShouldReturnNull()
        {

            var filePath = "nonexistent.json";


            var loadedDescription = DescriptionModel.LoadFromFile(filePath);


            Assert.IsNull(loadedDescription);
        }

    }
}
