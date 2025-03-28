using System.ComponentModel;

namespace WillPortfolio_Api.Domain.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public DateTime DeletedAt { get; protected set; }

    public bool Active { get; protected set; } = true;

    public void UpdateCreatedAt(DateTime createdAt)
    {
        this.CreatedAt = createdAt;
    }

    public void UpdateUpdatedAt(DateTime updatedAt)
    {
        this.UpdatedAt = updatedAt;
    }

    public void UpdateDeletedAt(DateTime deletedAt)
    {
        this.DeletedAt = deletedAt;
    }

    public void UpdateActive(bool active)
    {
        this.Active = active;
    }
}