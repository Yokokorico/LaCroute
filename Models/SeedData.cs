using LaCroute.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LaCroute.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LaCrouteContext(
                serviceProvider.GetRequiredService<DbContextOptions<LaCrouteContext>>()))
            {
                
                context.Database.EnsureCreated();

                if (context.Event.Any())
                {
                    return; // DB has been seeded
                }
                
                                if (context.Type.Any())
                {
                    return; // DB has been seeded
                }
                                if (context.Label.Any())
                {
                    return; // DB has been seeded
                }
                                if (context.ProductLabel.Any())
                {
                    return; // DB has been seeded
                }

                                if (context.Product.Any())
                {
                    return; // DB has been seeded
                }

                // Event
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


                // Types
                var planchesType = new TypeModel { Title = "Planches após" };
                var entreesType = new TypeModel { Title = "Entrées" };
                var platsType = new TypeModel { Title = "Plats" };
                var dessertsType = new TypeModel { Title = "Desserts" };
                var boissonsType = new TypeModel { Title = "Boissons" };

                context.Type.AddRange(
                    planchesType,
                    entreesType,
                    platsType,
                    dessertsType,
                    boissonsType
                );

                // Labels
                var vegetarien = new LabelModel
                {
                    Title = "Végétarien",
                    Svg = "M512 32c0 113.6-84.6 207.5-194.2 222c-7.1-53.4-30.6-101.6-65.3-139.3C290.8 46.3 364 0 448 0h32c17.7 0 32 14.3 32 32zM0 96C0 78.3 14.3 64 32 64H64c123.7 0 224 100.3 224 224v32V480c0 17.7-14.3 32-32 32s-32-14.3-32-32V320C100.3 320 0 219.7 0 96z",
                };
                var volaille = new LabelModel
                {
                    Title = "Volaille",
                    Svg = "M160 265.2c0 8.5-3.4 16.6-9.4 22.6l-26.8 26.8c-12.3 12.3-32.5 11.4-49.4 7.2C69.8 320.6 65 320 60 320c-33.1 0-60 26.9-60 60s26.9 60 60 60c6.3 0 12 5.7 12 12c0 33.1 26.9 60 60 60s60-26.9 60-60c0-5-.6-9.8-1.8-14.5c-4.2-16.9-5.2-37.1 7.2-49.4l26.8-26.8c6-6 14.1-9.4 22.6-9.4H336c6.3 0 12.4-.3 18.5-1c11.9-1.2 16.4-15.5 10.8-26c-8.5-15.8-13.3-33.8-13.3-53c0-61.9 50.1-112 112-112c8 0 15.7 .8 23.2 2.4c11.7 2.5 24.1-5.9 22-17.6C494.5 62.5 422.5 0 336 0C238.8 0 160 78.8 160 176v89.2z"
                };
                var porc = new LabelModel
                {
                    Title = "Porc",
                    Svg = "M439.2 1.2c11.2-3.2 23.2-.1 31.4 8.1L518 56.7l-26.5 7.9c-58 16.6-98.1 39.6-129.6 67.4c-31.2 27.5-53.2 59.1-75.1 90.9l-2.3 3.3C241.6 288.7 195 356.6 72.8 417.7L37.9 435.2 9.4 406.6c-7.3-7.3-10.6-17.6-9-27.8s8.1-18.9 17.3-23.5C136.1 296.2 180.9 231 223.3 169.3l2.3-3.4c21.8-31.8 44.9-64.9 77.7-93.9c33.4-29.5 75.8-53.6 135.9-70.8zM61.8 459l25.4-12.7c129.5-64.7 179.9-138.1 223.8-202l2.2-3.3c22.1-32.1 42.1-60.5 69.9-85.1c27.5-24.3 63.4-45.2 117.3-60.6l0 0 .2-.1 43.1-12.9 23 23c8 8 11.2 19.7 8.3 30.7s-11.3 19.6-22.2 22.7c-51.9 14.8-85.6 34.7-111.1 57.2c-26.1 23-45.1 49.9-67.3 82.1l-2.2 3.2C327.8 365.9 275.5 442 142.3 508.6c-12.3 6.2-27.2 3.7-36.9-6L61.8 459z"
                };
                var alcool = new LabelModel
                {
                    Title = "Alcool",
                    Svg = "M32 64c0-17.7 14.3-32 32-32H352c17.7 0 32 14.3 32 32V96h51.2c42.4 0 76.8 34.4 76.8 76.8V274.9c0 30.4-17.9 57.9-45.6 70.2L384 381.7V416c0 35.3-28.7 64-64 64H96c-35.3 0-64-28.7-64-64V64zM384 311.6l56.4-25.1c4.6-2.1 7.6-6.6 7.6-11.7V172.8c0-7.1-5.7-12.8-12.8-12.8H384V311.6zM160 144c0-8.8-7.2-16-16-16s-16 7.2-16 16V368c0 8.8 7.2 16 16 16s16-7.2 16-16V144zm64 0c0-8.8-7.2-16-16-16s-16 7.2-16 16V368c0 8.8 7.2 16 16 16s16-7.2 16-16V144zm64 0c0-8.8-7.2-16-16-16s-16 7.2-16 16V368c0 8.8 7.2 16 16 16s16-7.2 16-16V144z"
                };
                var soft = new LabelModel
                {
                    Title = "Sans alcool",
                    Svg = "M192 512C86 512 0 426 0 320C0 228.8 130.2 57.7 166.6 11.7C172.6 4.2 181.5 0 191.1 0h1.8c9.6 0 18.5 4.2 24.5 11.7C253.8 57.7 384 228.8 384 320c0 106-86 192-192 192zM96 336c0-8.8-7.2-16-16-16s-16 7.2-16 16c0 61.9 50.1 112 112 112c8.8 0 16-7.2 16-16s-7.2-16-16-16c-44.2 0-80-35.8-80-80z"
                };

                context.Label.AddRange(
                    vegetarien,
                    volaille,
                    porc,
                    alcool,
                    soft
                );

                // Product
                var pateEnCroute = new ProductModel
                {
                    Title = "Pâté en Croute",
                    Description = "Un délicieux pâté finement préparé, enveloppé dans une croûte croustillante et dorée. L'intérieur révèle un mélange savoureux de viandes sélectionnées, assaisonnées avec des herbes aromatiques, le tout offrant une expérience gustative exquise",
                    Price = 15.50,
                    Type = entreesType,
                    Thumbnail = "https://www.academiedugout.fr/images/66962/1200-686/pate-croute-richelieu-le-grand-livre-charcuterie-4-256.jpg?poix=50&poiy=50",
                };
                var pateCampagne = new ProductModel
                {
                    Title = "Pâté de Campagne",
                    Description = "Notre pâté de campagne est une ode à la tradition culinaire française. Composé de viandes hachées, de foie de volaille et d'épices authentiques, ce plat rustique offre une texture délicieusement granuleuse et des saveurs riches qui évoquent la chaleur de la campagne",
                    Price = 12.75,
                    Type = entreesType,
                    Thumbnail = "https://www.les-fins-gourmets.com/wp-content/uploads/2023/02/pate-campagne-scaled.jpg",
                };
                var potjevlesch = new ProductModel
                {
                    Title = "Potjevlesch",
                    Description = "Le Potjevlesch est un plat régional du nord de la France, mêlant harmonieusement trois viandes tendres : porc, veau et lapin. Cuit lentement dans un mélange de bouillon parfumé, ce plat offre des saveurs complexes et réconfortantes, soulignées par une texture fondante.",
                    Price = 18.90,
                    Type = platsType,
                    Thumbnail = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTU4TV7Weu2aWfLicGrgpczrJKFn-rzviMJiA&usqp=CAU",
                };
                context.Product.AddRange(
                    pateEnCroute,
                    pateCampagne,
                    potjevlesch
                );

                //ProductLabel
                context.ProductLabel.AddRange(
                    new ProductLabelModel
                    {
                        Product = pateEnCroute,
                        Label = porc
                    },
                    new ProductLabelModel
                    {
                        Product = pateCampagne,
                        Label = porc
                    },
                    new ProductLabelModel
                    {
                        Product = potjevlesch,
                        Label = porc
                    },
                    new ProductLabelModel
                    {
                        Product = potjevlesch,
                        Label = volaille
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
}
