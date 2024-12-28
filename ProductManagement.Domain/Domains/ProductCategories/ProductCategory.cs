using ProductManagement.Domain.Base;

namespace ProductManagement.Domain.Domains.ProductCategories;

public class ProductCategory : BaseEntity
{
    public string Name { get; private set; }


    public ProductCategory(string name)
    {
        Id = Guid.NewGuid();
        SetName(name);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty.");

        Name = name;
    }
}

