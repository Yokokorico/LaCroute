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
                },
                new EventModel
                {
                    title = "LA FETE DU PATE",
                    description = "Officia et laborum ex culpa. Eiusmod eu ad ullamco ad. Dolore veniam reprehenderit aliqua cillum adipisicing. Cillum nisi deserunt anim reprehenderit nisi ea incididunt ullamco commodo aliqua. Ad nisi mollit eu sunt ad consequat commodo amet pariatur. Ipsum officia et non officia sint cillum ad Lorem est nulla est enim. <br> Veniam labore irure nisi irure. Eiusmod aliquip id eu nisi. Laboris incididunt eiusmod velit consectetur excepteur anim aliqua ut. Esse ex anim sunt exercitation dolore sunt pariatur laboris magna. Ut ipsum dolore eiusmod sint commodo minim ex laboris.",
                    thumbnail = "https://www.corpo-events.fr/wp-content/uploads/2013/09/organisation-seminaire-incentive-840x334.jpg",
                    date = DateTime.Parse("1989-2-12"),
                },
                new EventModel
                {
                    title = "PATE AMBULANT",
                    description = "Officia et laborum ex culpa. Eiusmod eu ad ullamco ad. Dolore veniam reprehenderit aliqua cillum adipisicing. Cillum nisi deserunt anim reprehenderit nisi ea incididunt ullamco commodo aliqua. Ad nisi mollit eu sunt ad consequat commodo amet pariatur. Ipsum officia et non officia sint cillum ad Lorem est nulla est enim. <br> Veniam labore irure nisi irure. Eiusmod aliquip id eu nisi. Laboris incididunt eiusmod velit consectetur excepteur anim aliqua ut. Esse ex anim sunt exercitation dolore sunt pariatur laboris magna. Ut ipsum dolore eiusmod sint commodo minim ex laboris.",
                    thumbnail = "https://www.corpo-events.fr/wp-content/uploads/2013/09/organisation-seminaire-incentive-840x334.jpg",
                    date = DateTime.Parse("2022-2-12"),
                },
                new EventModel
                {
                    title = "Gare au pâté",
                    description = "Officia et laborum ex culpa. Eiusmod eu ad ullamco ad. Dolore veniam reprehenderit aliqua cillum adipisicing. Cillum nisi deserunt anim reprehenderit nisi ea incididunt ullamco commodo aliqua. Ad nisi mollit eu sunt ad consequat commodo amet pariatur. Ipsum officia et non officia sint cillum ad Lorem est nulla est enim. <br> Veniam labore irure nisi irure. Eiusmod aliquip id eu nisi. Laboris incididunt eiusmod velit consectetur excepteur anim aliqua ut. Esse ex anim sunt exercitation dolore sunt pariatur laboris magna. Ut ipsum dolore eiusmod sint commodo minim ex laboris.",
                    thumbnail = "https://www.corpo-events.fr/wp-content/uploads/2013/09/organisation-seminaire-incentive-840x334.jpg",
                    date = DateTime.Parse("2023-2-12"),
                }
            );
            context.SaveChanges();
        }
    }
}