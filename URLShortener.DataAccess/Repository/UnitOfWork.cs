using URLShortener.DataAccess.Data;
using URLShortener.DataAccess.Repository.IRepository;

namespace URLShortener.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IUrlItemRepository UrlItem { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {

            _db = db;
            UrlItem = new UrlItemRepository(db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
