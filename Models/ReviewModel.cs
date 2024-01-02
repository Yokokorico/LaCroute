using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Models;

public class ReviewModel{
    [Key]
    public int Id {get; set;}
    public string? Name { get; set; }
	public string? Title {get; set;}
    public string? Description {get; set;}
    public int Rating {get; set;}
    public DateTime created_at {get; set;}
    public DateTime updated_at {get; set;}
}