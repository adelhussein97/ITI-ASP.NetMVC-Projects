

using System.ComponentModel.DataAnnotations;

namespace APIDTO.Category
{
    public class CategoryMinimalDto
    {
        public int Id { get; set; }

        [MinLength(3,ErrorMessage="Min Must 3 Char or More"),MaxLength(20)]
        public string Name { get; set; }
    }
}
