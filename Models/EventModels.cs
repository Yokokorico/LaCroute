using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Models;

public class EventModels{
    [Key]
    public int id_event {get; set;}
    public string title {get; set;}
    public string description {get; set;}
    public string thumbnail {get; set;}
    public DateTime date {get; set;}
    public DateTime create_at {get; set;}
    public DateTime update_at {get; set;}
}