using APIDTO.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDTO.Category
{
    public class CategoryDetailsDto
    {
       

        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryMinimalDto? ParentCategories { get; set; }
        public IEnumerable<CategoryMinimalDto>? SubCategories { get; set; }

        public IEnumerable<ProductMinimalDto>? Products { get; set; }


        public CategoryDetailsDto(int id, string name, CategoryMinimalDto? parentCategories=null,
            IEnumerable<CategoryMinimalDto>? subCategories=null, IEnumerable<ProductMinimalDto>? products=null)
        {
            Id = id;
            Name = name;
            ParentCategories = parentCategories;
            SubCategories = subCategories;
            Products = products;
        }
        public CategoryDetailsDto(int id, string name):this(id,name,null)
        {

        }
        

    }
}
