using APIDTO.Product;
using Domains;


namespace Application.Contract
{
    public interface IProductRepository:IRepository<Product, long>
    {
        Task<IEnumerable<ProductDetailsDto>> FilterByAsync(string? Name=null,int? FromPrice=null,int? ToPrice=null,bool? IsAvailable=null,bool? HasDiscount=null,int? CategoryID =null);

    }
}
