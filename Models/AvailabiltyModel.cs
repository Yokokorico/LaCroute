using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Models;

public class AvailabiltyModel
{
    [Key]
    public int Id { get; set; }
    public ServiceModel service { get; set; }
    public TableModel table { get; set; }
    public bool is_available {get; set;}
    public DateTime Created_at { get; set; } = DateTime.Now;
    public DateTime Updated_at { get; set; } = DateTime.Now;
}