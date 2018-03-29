using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore(); // returns instance of CitiesDataStore

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {

            // init dummy data
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Dummy Data - New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto() {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visited urban park in the United States." },
                        new PointOfInterestDto() {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattan." }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Dummy Data - Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto() {
                            Id = 3,
                            Name = "Cathedral of Our Lady",
                            Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans." },
                        new PointOfInterestDto() {
                            Id = 4,
                            Name = "Antwerp Central Station",
                            Description = "The the finest example of railway architecture in Belgium." }
                    }
                },
                new CityDto()
                {
                    Id= 3,
                    Name = "Dummy Data - Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto() {
                            Id = 5,
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel." },
                        new PointOfInterestDto() {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "The world's largest museum." }
                    }
                },
                new CityDto()
                {
                    Id= 4,
                    Name = "Dummy Data - Cleveland",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto() {
                            Id = 7,
                            Name = "Rock & Roll Hall of Fame",
                            Description = "A fame hall for rocks and rolls." },
                        new PointOfInterestDto() {
                            Id = 8,
                            Name = "The Cleveland Art Museum",
                            Description = "The world's largest museum... except not the world, just Cleveland" }
                    }
                },
                new CityDto()
                {
                    Id= 5,
                    Name = "Dummy Data - Akron",
                    Description = "LOL. The Rubber Capital.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto() {
                            Id = 9,
                            Name = "Hower House",
                            Description = "Hower House is a Second Empire Italianate structure, built in 1871 by Akron Industrialist, John Henry Hower and his wife, Susan Youngker Hower." },
                        new PointOfInterestDto() {
                            Id = 10,
                            Name = "Stan Hywet Hall & Gardens",
                            Description = "Stan Hywet is Akron’s first and largest National Historic Landmark, and is also the nation’s 6th largest historic home open to the public." }
                    }
                },
                new CityDto()
                {
                    Id= 6,
                    Name = "Dummy Data - Verona",
                    Description = "It has those couple of people in it.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto() {
                            Id = 11,
                            Name = "Thomas Edison National Historical Park",
                            Description = "Thomas Edison's home and laboratory are a step back in time, when machines were run by belts and pulleys and music was played on phonographs." },
                        new PointOfInterestDto() {
                            Id = 12,
                            Name = "Montclair Art Museum",
                            Description = "The world's largest museum in Montclair, NJ." }
                    }
                },
                new CityDto()
                {
                    Id= 7,
                    Name = "Dummy Data - Detroit",
                    Description = "They used to make cars here.",
                    //PointsOfInterest = null // does't work
                }
            };
        }
    }
}
