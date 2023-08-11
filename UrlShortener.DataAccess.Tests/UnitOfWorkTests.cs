using Microsoft.EntityFrameworkCore;
using URLShortener.DataAccess.Data;
using URLShortener.DataAccess.Repository;
using URLShortener.DataAccess.Repository.IRepository;
using URLShortener.Models;

namespace URLShortener.Tests
{
    [TestClass]
    public class UnitOfWorkTests
    {
        [TestMethod]
        public void Save_CallsSaveChanges()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                // Create a real UrlItemRepository
                var urlItemRepository = new UrlItemRepository(context);

                // Create a UnitOfWork using the real context and repository
                var unitOfWork = new UnitOfWork(context);
                unitOfWork.UrlItem = urlItemRepository;

                // Add a sample UrlItem to the context
                context.UrlItems.Add(new UrlItem { Url = "https://example.com" });
                context.SaveChanges();

                // Act
                unitOfWork.Save();

                // Assert
                Assert.AreEqual(1, context.UrlItems.Count());
            }
        }

        [TestMethod]
        public void UrlItem_InitializedCorrectly()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                // Create a UnitOfWork using the real context
                var unitOfWork = new UnitOfWork(context);

                // Act
                var urlItemRepository = unitOfWork.UrlItem;

                // Assert
                Assert.IsNotNull(urlItemRepository);
                Assert.IsInstanceOfType(urlItemRepository, typeof(IUrlItemRepository));
            }
        }
    }
}