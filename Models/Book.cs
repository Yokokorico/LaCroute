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
    [Phone(ErrorMessage ="Merci de renseigner un numéro de téléphone valide")]
    [Required(ErrorMessage = "Le numéro de téléphone est requis pour réserver.")]
    public string phoneNumber {get; set;}
    [Range(1,10,ErrorMessage = "Merci de mettre entre 1 et 10 places")]
    [Required(ErrorMessage = "Le nombre de personnes est requis pour réserver.")]
    public int seats{get; set;}

    public DateTime created_at {get; set;} = DateTime.Now;
    public DateTime updated_at {get; set;} = DateTime.Now;
}

