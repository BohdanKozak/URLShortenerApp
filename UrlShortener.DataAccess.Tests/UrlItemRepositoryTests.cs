using Microsoft.EntityFrameworkCore;
using URLShortener.DataAccess.Data;
using URLShortener.DataAccess.Repository;
using URLShortener.Models;

namespace Repository.Tests
{
    [TestClass]
    public class UrlItemRepositoryTests
    {
        [TestMethod]
        public void Add_SetsCreatedDateAndCallsDbAdd()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var urlItemRepository = new UrlItemRepository(context);
                var entityToAdd = new UrlItem { Url = "https://example.com" };

                // Act
                urlItemRepository.Add(entityToAdd);
                context.SaveChanges(); // ���������� � ���'������ ��� ����� � ���'��

                // Assert
                Assert.IsNotNull(entityToAdd.CreatedDate);
                Assert.AreEqual(1, context.UrlItems.Count()); // �������� �������� ������ ������ � ���
            }
        }
        [TestMethod]
        public void Update_CallsDbUpdate()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UnitTestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var urlItemRepository = new UrlItemRepository(context);
                var entityToUpdate = new UrlItem { Id = 1, Url = "https://example.com" };
                urlItemRepository.Add(entityToUpdate); // ������ ��'��� � ���'������ ���� �����

                // Act
                entityToUpdate.Url = "https://updated-example.com";
                urlItemRepository.Update(entityToUpdate);
                context.SaveChanges(); // ���������� � ���'������ ��� ����� � ���'��

                // Assert
                Assert.AreEqual("https://updated-example.com", context.UrlItems.Find(entityToUpdate.Id).Url);
            }
        }

    }
}