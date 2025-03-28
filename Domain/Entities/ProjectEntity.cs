using System.ComponentModel.DataAnnotations.Schema;

namespace WillPortfolio_Api.Domain.Entities;

public class ProjectEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid PortfolioId { get; set; }

    [ForeignKey("PortfolioId")]
    public PortfolioEntity Portfolio { get; set; } 
}