namespace Application.Dtos.Products
{
    /// <summary>
    /// Product Create DTO
    /// </summary>
    public class ProductCreateDto
    {
        
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}