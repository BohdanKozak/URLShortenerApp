namespace URLShortener.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUrlItemRepository UrlItem { get; }

        void Save();


    }
}
