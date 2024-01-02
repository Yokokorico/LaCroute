using LaCroute.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LaCroute.Data;
using System;
using System.Linq;

namespace LaCroute.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new LaCrouteContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<LaCrouteContext>>()))
        {
            // Look for any movies.
            if (context.Event.Any())
            {
                return;   // DB has been seeded
            }
            context.Event.AddRange(
                new EventModel
                {
                    title = "When Harry Met Sally",
                    description = "WALLAH",
                    thumbnail = "https://www.corpo-events.fr/wp-content/uploads/2013/09/organisation-seminaire-incentive-840x334.jpg",
                    date = DateTime.Parse("1989-2-12"),
                }
            );

            context.Review.AddRange(

                new ReviewModel
                {
                    Name = "Alice",
                    Title = "Une expérience transcendantale !",
                    Description = "Ma visite à La Croûte a été littéralement transcendante ! Chaque bouchée de leurs pâtés était comme une explosion de bonheur dans ma bouche. Je me suis senti transporté dans un monde de délices culinaires où chaque instant était un chef-d'œuvre gastronomique.",
                    Rating = 5 // Mettez la note entre 1 et 5
                },
                 new ReviewModel
                 {
                     Name = "Bob",
                     Title = "La quintessence de la gastronomie !",
                     Description = "Si je pouvais donner dix étoiles, je le ferais sans hésiter ! Ma soirée à La Croûte a été le sommet de toutes les expériences gustatives. Les pâtés étaient si divinement parfaits que j'ai presque cru être dans un rêve culinaire. Absolument époustouflant !",
                     Rating = 5 // Mettez la note entre 1 et 5
                 },
                new ReviewModel
                {
                    Name = "Charlie",
                    Title = "Une symphonie de saveurs !",
                    Description = "Je pensais avoir goûté à la perfection, mais La Croûte a complètement redéfini mes attentes culinaires. Chaque plat était comme une symphonie de saveurs coordonnée avec une précision impeccable. Ma vie culinaire a atteint son apogée ce soir-là !",
                    Rating = 5 // Mettez la note entre 1 et 5
                },
                new ReviewModel
                {
                    Name = "David",
                    Title = "Un conte de fées culinaire !",
                    Description = "Mes papilles ont été bénies par les chefs de La Croûte. Chaque morsure de leurs pâtés était littéralement un voyage dans le nirvana des saveurs. C'était bien plus qu'un repas, c'était une expérience mystique que je chérirai éternellement.",
                    Rating = 5 // Mettez la note entre 1 et 5
                },
                new ReviewModel
                {
                    Name = "Eva",
                    Title = "Un paradis pour gourmets !",
                    Description = "La Croute devrait être inscrite dans les annales de l'histoire gastronomique ! Chaque seconde passée là-bas était comme un conte de fées culinaire. Les pâtés étaient tellement parfaits que j'ai presque eu l'impression de vivre dans un paradis pour gourmets !",
                    Rating = 5 // Mettez la note entre 1 et 5
                }
            );

            context.SaveChanges();
        }
    }
}
