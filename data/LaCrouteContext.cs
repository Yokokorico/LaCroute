using System.Security.Cryptography.X509Certificates;
using LaCroute.Models;
using Microsoft.EntityFrameworkCore;
namespace LaCroute.Data
  {
  public class LaCrouteContext: DbContext
  {
    public LaCrouteContext(DbContextOptions<LaCrouteContext> options) :
    base(options)
      {
      }
    public DbSet<EventModels> Events { get; set;} = default!;
  }
}