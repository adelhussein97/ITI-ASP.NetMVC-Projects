using APIDTO.Category;
using Application.Contract;
using Azure.Core;
using Domains;
using ECommerceDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CategoryRepository : Repository<Category,ECommerce_DbContext,int> , ICategoryRepository
    {
        public CategoryRepository(ECommerce_DbContext db):base(db)
        {
            
        }

       

        public async Task<IEnumerable<Category>> FilterByAsync(string? Filter = null,int? parentCategoryId= null)
        {
            IEnumerable<Category> category= Context.Categories
                .Where(c=> Filter==null || c.Name.ToLower().Contains(Filter.ToLower()))
                .Where(c=>parentCategoryId==null || 
                (c.ParentCategories != null ?  c.ParentCategories.Id == parentCategoryId :false));

            return await Task.FromResult( category);
            
        }
       


    }
}
