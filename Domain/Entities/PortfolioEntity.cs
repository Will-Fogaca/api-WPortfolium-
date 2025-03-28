using System.ComponentModel.DataAnnotations.Schema;

namespace WillPortfolio_Api.Domain.Entities;

public class PortfolioEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string Introduction { get; set; } = string.Empty;
    public List<ProjectEntity> Projects { get; set; } = new();

    public Guid UserId { get; protected set; }

    public PortfolioEntity(Guid userId, string description, string about, string introduction)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Description = description;
        About = about;
        Introduction = introduction;
        Projects = new List<ProjectEntity>();
    }

    public PortfolioEntity() { }
}
