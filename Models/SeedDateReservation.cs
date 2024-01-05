using LaCroute.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LaCroute.Models
{
    public static class SeedDataReservation
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LaCrouteContext(
                serviceProvider.GetRequiredService<DbContextOptions<LaCrouteContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Table.Any())
                {
                    return; // DB has been seeded
                }
                if (context.Service.Any())
                {
                    return; // DB has been seeded
                }
                if (context.Availabilties.Any())
                {
                    return; // DB has been seeded
                }
                var tableModel = new TableModel
                {
                    number = 1,
                    seat = 4,
                    availabilties = new List<AvailabiltyModel>(), // Remplacez ceci par la liste réelle d'AvailabiltyModel
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now,
                };

                context.Table.Add(tableModel);

                var serviceModel = new ServiceModel
                {
                    date = DateTime.Now,
                    availabilties = new List<AvailabiltyModel>(), // Remplacez ceci par la liste réelle d'AvailabiltyModel
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now,
                };

                context.Service.Add(serviceModel);

                var availabiltyModel = new AvailabiltyModel
                {
                    service = serviceModel,
                    table = tableModel,
                    is_available = true,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now,
                };

                context.Availabilties.Add(availabiltyModel);
            }
        }
    }
}