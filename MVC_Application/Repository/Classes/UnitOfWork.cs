using MVC_Application.Database;
using MVC_Application.Repository.Interfaces;

namespace MVC_Application.Repository.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private  readonly ApplicationDbContext applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext=applicationDbContext;
            CategoryRepository=new CategoryRepository(applicationDbContext);
            CoverTypeRepository=new CoverTypeRepository(applicationDbContext);
            ShoppingCartRepository=new ShoppingCartRepository(applicationDbContext);
            ProductRepository=new ProductRepository(applicationDbContext);
            ApplicationUserRepository=new ApplicationUserRepository(applicationDbContext);
            OrderDetailRepository=new OrderDetailRepository(applicationDbContext);
            OrderHeaderRepository=new OrderHeaderRepository(applicationDbContext);
            CompanyRepository=new CompanyRepository(applicationDbContext);
        }
		public ICategoryRepository CategoryRepository { get; }

		public ICoverTypeRepository CoverTypeRepository { get; }

		public IProductRepository ProductRepository {get; }

		public ICompanyRepository CompanyRepository { get; }

		public IShoppingCartRepository ShoppingCartRepository { get; }

		public IApplicationUserRepository ApplicationUserRepository { get; }

		public IOrderDetailRepository OrderDetailRepository { get; }

		public IOrderHeaderRepository OrderHeaderRepository { get; }

		public void Save()
        {
            applicationDbContext.SaveChanges();
        }
    }
}
