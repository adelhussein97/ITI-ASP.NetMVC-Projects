
using APIDTO.Category;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Application.Contract
{
    public interface ICategoryRepository : IRepository<Category,int>
    {
        Task<IEnumerable<Category>> FilterByAsync(string? Filter = null,int ? ParentCategoryId=null);

    }
}
