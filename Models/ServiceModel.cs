using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Models;

public class ServiceModel
{
    [Key]
    public int Id { get; set; }
    public DateTime date { get; set; }
    public ICollection<AvailabiltyModel> availabilties {get; set;}
    public DateTime Created_at { get; set; } = DateTime.Now;
    public DateTime Updated_at { get; set; } = DateTime.Now;
}