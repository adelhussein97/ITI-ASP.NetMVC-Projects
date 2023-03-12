namespace APIDTO.Product
{
    public class ProductDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public string? Description { get; set; }
        public ProductDetailsDto(long id, string name, float unitPrice, string? description=null)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            Description = description;
        }
    }
}
