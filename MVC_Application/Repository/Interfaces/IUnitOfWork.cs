namespace MVC_Application.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
		ICoverTypeRepository CoverTypeRepository { get; }
		IProductRepository ProductRepository { get; }
		ICompanyRepository CompanyRepository { get; }
		IShoppingCartRepository ShoppingCartRepository { get; }
		IApplicationUserRepository ApplicationUserRepository { get; }
		IOrderDetailRepository OrderDetailRepository { get; }
		IOrderHeaderRepository OrderHeaderRepository { get; }
		void Save();
    }
}
