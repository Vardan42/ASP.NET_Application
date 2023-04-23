using MVC_Application.Database;
using MVC_Application.Models;
using MVC_Application.Repository.Interfaces;

namespace MVC_Application.Repository.Classes
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private readonly ApplicationDbContext applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void Update(Category category)
        {
            applicationDbContext.Update(category);
        }
    }
}
