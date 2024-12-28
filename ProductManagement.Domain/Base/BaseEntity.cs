namespace ProductManagement.Domain.Base;

public class BaseEntity
{
    public Guid Id { get; protected set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        IsActive = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void SetUpdateTime()
    {
        UpdatedAt = DateTime.Now;
    }
    public void SetIsActive(bool isActive)
    {
        IsActive = isActive;
    }
    public void SetIsDeleted(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }
}

