using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Models;

public class LabelModel
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Svg { get; set; }
    public ICollection<ProductLabelModel>? ProductLabel { get; set; }
    public DateTime Created_at { get; set; } = DateTime.Now;
    public DateTime Updated_at { get; set; } = DateTime.Now;
}