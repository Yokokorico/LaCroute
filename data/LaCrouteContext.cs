using System.Security.Cryptography.X509Certificates;
using LaCroute.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LaCroute.Data
{
  public class LaCrouteContext : IdentityDbContext
  {
    public LaCrouteContext(DbContextOptions<LaCrouteContext> options) :
    base(options)
    {
    }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   base.OnModelCreating(modelBuilder);
    //   modelBuilder.Entity<ProductLabelModel>().HasKey(t => new { t.ProductId, t.LabelId });
    // }
    public DbSet<EventModel> Event { get; set; } = default!;
    public DbSet<TypeModel> Type { get; set; } = default!;
    public DbSet<LabelModel> Label { get; set; } = default!;
    public DbSet<ProductModel> Product { get; set; } = default!;
    public DbSet<ProductLabelModel> ProductLabel { get; set; } = default!;
    public DbSet<ReviewModel> Review { get; set; } = default!;
    public DbSet<TableModel> Table {get; set;} = default!;
    public DbSet<ServiceModel> Service {get; set;} = default!;
    public DbSet<AvailabiltyModel> Availabilties {get; set;} = default!;
    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<AdminModel> Admin { get; set; } = default!;
  }
}