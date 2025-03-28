using Microsoft.EntityFrameworkCore;
using WillPortfolio_Api.Domain.Entities;

namespace WillPortfolio_Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<PortfolioEntity> Portfolios { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    
}