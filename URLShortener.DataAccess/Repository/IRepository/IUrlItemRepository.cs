using URLShortener.Models;

namespace URLShortener.DataAccess.Repository.IRepository
{
    public interface IUrlItemRepository : IRepository<UrlItem>
    {
        public void Update(UrlItem obj);
        public void Add(UrlItem entity);




    }


}
