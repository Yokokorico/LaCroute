using LaCroute.Models;
using System.Collections.Generic;
namespace LaCroute.ViewModels
{
    // ViewModel pour la page d'accueil
    public class HomeViewModel
    {

        public List<EventModel> Events { get; set; }
        public List<ReviewModel> Reviews { get; set; }

        public HomeViewModel()
        {
            Events = new List<EventModel>();
            // Reviews = new List<ReviewModel>();
        }
    }
}