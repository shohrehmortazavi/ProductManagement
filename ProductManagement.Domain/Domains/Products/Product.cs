using ProductManagement.Domain.Base;
namespace ProductManagement.Domain.Domains.Products;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public Guid ProductCategoryId { get; private set; }
    
    public Product(string name,
                   decimal price,
                   Guid productCategoryId)
    {
        SetName(name);
        SetPrice(price);
        SetCategory(productCategoryId);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.");
        Name = name;
    }

    public void SetPrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");
        Price = price;
    }

    public void SetCategory(Guid productCategoryId)
    {
        if ( productCategoryId == Guid.Empty)
            throw new ArgumentException("ProductCategoryId cannot be an empty GUID.");

        ProductCategoryId = productCategoryId;
    }

    public void Update(string name, decimal price, Guid productCategoryId)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Product name cannot be empty.", nameof(name));

        if (price <= 0)
            throw new ArgumentException("Product price must be greater than zero.", nameof(price));

        if (productCategoryId != ProductCategoryId && productCategoryId != Guid.Empty)
            ProductCategoryId = productCategoryId;

        Name = name;
        Price = price;
    }

}
