using System.ComponentModel.DataAnnotations;
using URLShortener.Models;

namespace UrlShortener.Models.Tests
{
    [TestClass]
    public class UrlItemModelTest
    {
        [TestMethod]
        public void UrlItem_UrlMaxLength_ShouldBe255()
        {

            var urlItem = new UrlItem();


            var maxLength = urlItem.GetType().GetProperty("Url")?
                    .GetCustomAttributes(typeof(MaxLengthAttribute), true)[0]
                as MaxLengthAttribute;


            Assert.IsNotNull(maxLength);
            Assert.AreEqual(255, maxLength.Length);
        }
    }
}