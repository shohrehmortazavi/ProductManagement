namespace ProductManagement.Application.Products.Dtos;

public class ProductResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid ProductCategoryId { get; set; }
}
