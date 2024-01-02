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
            context.SaveChanges();
        }
    }
}