using URLShortener.Models;

namespace URLShortener.DataAccess.Repository.IRepository
{
    public interface IUrlItemRepository : IRepository<UrlItem>
    {
        void Save();
        public void Update(UrlItem obj);

    }


}
