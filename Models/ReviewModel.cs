using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Models;

public class ReviewModel{
    [Key]
    public int Id {get; set;}
    [Required(ErrorMessage = "Veuillez entrer votre Prénom")]
    public string? Name { get; set; }
	[StringLength(100, ErrorMessage ="Le Titre ne doit pas dépasser 100 caractères")]
    [Required(ErrorMessage = "Veuillez entrer un titre à votre avis.")]
    public string? Title {get; set;}
    [StringLength(1000, ErrorMessage ="Le message ne doit pas dépasser 1000 caractères")]
    [Required(ErrorMessage = "Veuillez entrer un message")]
    public string? Description {get; set;}
    [Required(ErrorMessage = "Veuillez selectionné une note")]
    public int Rating {get; set;}
    public DateTime created_at {get; set;}
    public DateTime updated_at {get; set;}
}