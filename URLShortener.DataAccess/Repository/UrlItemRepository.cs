using URLShortener.DataAccess.Data;
using URLShortener.DataAccess.Repository.IRepository;
using URLShortener.Models;

namespace URLShortener.DataAccess.Repository
{
    public class UrlItemRepository : Repository<UrlItem>, IUrlItemRepository
    {
        private ApplicationDbContext _db;
        public UrlItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(UrlItem obj)
        {
            _db.Update(obj);
        }
    }
}
