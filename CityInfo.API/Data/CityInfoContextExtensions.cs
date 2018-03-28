using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;

namespace CityInfo.API.Data
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Cities.Any())
            {
                var cities = new List<City>()
                {
                    new City()
                    {
                        Name = "New York City",
                        Description = "The never sleeping city with that big park.",
                        PointsOfInterest = new List<PointOfInterest>()
                        {
                            new PointOfInterest() {
                                Name = "Central Park",
                                Description = "The most visited urban park in the United States." },
                            new PointOfInterest() {
                                Name = "Empire State Building",
                                Description = "A 102-story skyscraper located in midtown Manhattan." }
                        }
                    },
                    new City()
                    {
                        Name = "Antwerp",
                        Description = "The one with the cathedral that was never really finished.",
                        PointsOfInterest = new List<PointOfInterest>()
                        {
                            new PointOfInterest() {
                                Name = "Cathedral of Our Lady",
                                Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."},
                            new PointOfInterest() {
                                Name = "Antwerp Central Station",
                                Description = "The the finest example of railway architecture in Belgium." }
                        }
                    },
                    new City()
                    {
                        Name = "Paris",
                        Description = "The one with that big ass tower.",
                        PointsOfInterest = new List<PointOfInterest>()
                        {
                            new PointOfInterest() {
                                Name = "Eiffel Tower",
                                Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel." },
                            new PointOfInterest() {
                                Name = "The Louvre",
                                Description = "The world's largest museum." }
                        }
                    },
                    new City()
                    {
                        Name = "Cleveland",
                        Description = "The one with that really offensive team... and the other team that's also offensive.",
                        PointsOfInterest = new List<PointOfInterest>()
                        {
                            new PointOfInterest() {
                                Name = "Rock & Roll Hall of Fame",
                                Description = "A fame hall for rocks and rolls." },
                            new PointOfInterest() {
                                Name = "The Cleveland Art Museum",
                                Description = "The world's largest museum... except not the world, just Cleveland" }
                        }
                    },
                    new City()
                    {
                        Name = "Akron",
                        Description = "LOL. The Rubber Capital.",
                        PointsOfInterest = new List<PointOfInterest>()
                        {
                            new PointOfInterest() {
                                Name = "Hower House",
                                Description = "Hower House is a Second Empire Italianate structure, built in 1871 by Akron Industrialist, John Henry Hower and his wife, Susan Youngker Hower." },
                            new PointOfInterest() {
                                Name = "Stan Hywet Hall & Gardens",
                                Description = "Stan Hywet is Akron’s first and largest National Historic Landmark, and is also the nation’s 6th largest historic home open to the public." }
                        }
                    },
                    new City()
                    {
                        Name = "Verona",
                        Description = "It has those couple of people in it.",
                        PointsOfInterest = new List<PointOfInterest>()
                        {
                            new PointOfInterest() {
                                Name = "Thomas Edison National Historical Park",
                                Description = "Thomas Edison's home and laboratory are a step back in time, when machines were run by belts and pulleys and music was played on phonographs." },
                            new PointOfInterest() {
                                Name = "Montclair Art Museum",
                                Description = "The world's largest museum in Montclair, NJ." }
                        }
                    },

                    new City()
                    {
                        Name = "Detroit",
                        Description = "They used to make cars here.",
                        //PointsOfInterest = null // does't work
                    }
                };

                context.Cities.AddRange(cities);
                context.SaveChanges();
            }
        }
    }
}
