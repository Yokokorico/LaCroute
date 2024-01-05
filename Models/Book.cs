using System.ComponentModel.DataAnnotations;

namespace LaCroute.Models;
public class Book{
    [Key]
    public int id {get; set;}
    public DateOnly date {get; set;}
    [Required(ErrorMessage = "Veuillez sélectionner une heure.")]
    [DataType(DataType.Time)]
    public TimeSpan time {get; set;}
    public string name {get; set;}
    public string phoneNumber {get; set;}
    public int seats{get; set;}
}

