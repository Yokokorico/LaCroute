using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Models;

public class EventModel{
    [Key]
    public int id {get; set;}
    public string title {get; set;}
    public string description {get; set;}
    public string thumbnail {get; set;}
    public DateOnly date {get; set;}
    public DateTime created_at {get; set;}
    public DateTime updated_at {get; set;}
}