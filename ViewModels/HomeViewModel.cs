using LaCroute.Models;
using System.Collections.Generic;
namespace LaCroute.ViewModels
{
    // ViewModel pour la page d'accueil
    public class HomeViewModel
    {

        public List<EventModel> Events { get; set; }

        public HomeViewModel()
        {
            Events = new List<EventModel>();
        }
    }
}