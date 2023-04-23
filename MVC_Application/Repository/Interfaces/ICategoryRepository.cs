using MVC_Application.Models;

namespace MVC_Application.Repository.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
            void Update(Category category);
    }
}
