
using APIDTO.Product;
using Application.Contract;
using Domains;
using ECommerceDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure
{
    public class ProductRepository : Repository<Product, ECommerce_DbContext, long>, IProductRepository
    {
        public ProductRepository(ECommerce_DbContext db) : base(db)
        {

        }
        public async Task<IEnumerable<ProductDetailsDto>> FilterByAsync(string? Name = null, int? FromPrice = null, int? ToPrice = null, bool? IsAvailable = null, bool? HasDiscount = null, int? CategoryID = null)
        {
            if (Name == null)
            {
                return await Context.Products
                .Select(a => new ProductDetailsDto(a.Id, a.Name,a.UnitPrice,a.Discription)).ToListAsync();
            }
            else
            {
                return await Context.Products.Where(a => a.Name == Name)
                .Select(a => new ProductDetailsDto(a.Id, a.Name, a.UnitPrice, a.Discription)).ToListAsync();
            }
        }

        
    }
}
