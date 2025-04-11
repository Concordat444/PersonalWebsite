using Microsoft.EntityFrameworkCore;

namespace PersonalWebsite.Models.StoreModels
{
    public static class SeedStoreData
    {
        public static void SeedDatabase(StoreContext context)
        {
            context.Database.Migrate();
            if (!context.Games.Any()
                    && !context.ProductOwners.Any()
                    && !context.Categories.Any())
            {
                ProductOwner po1 = new()
                {
                    Username = "JohnDoe1",
                    FirstName = "John",
                    LastName = "Doe",
                    City = "Atlanta",
                    EMail = "johndoe1@example.com"
                };
                ProductOwner po2 = new()
                {
                    Username = "JaneDoe1",
                    FirstName = "Jane",
                    LastName = "Doe",
                    City = "Los Angeles",
                    EMail = "janedoe1@example.com"
                };

                Category c1 = new()
                {
                    Name = "Ancient"
                };
                Category c2 = new()
                {
                    Name = "Napoleonic"
                };
                Category c3 = new()
                {
                    Name = "WW2"
                };
                
                //define publishers
                Publisher _p1AvalonHill = new()
                {
                    
                    PublisherName = "The Avalon Hill Game Co"
                };
                Publisher _p2ValleyGames = new()
                {
                    
                    PublisherName = "Valley Games, Inc."
                };
                Publisher _p3GMTGames = new()
                {
                    
                    PublisherName = "GMTGames"
                };
                Publisher _p4AustralianDesignGroup = new()
                {
                    
                    PublisherName = "Australian Design Group"
                };
                Publisher _p5MayfairGames = new()
                {
                    
                    PublisherName = "Mayfair Games"
                };
                Publisher _p6Phalanx = new()
                {
                    
                    PublisherName = "PHALANX"
                };
                Publisher _p7DaysOfWonder = new()
                {
                    
                    PublisherName = "Days of Wonder"
                };
                Publisher _p8ADCBlackfire = new()
                {
                    
                    PublisherName = "ADC Blackfire Entertainment"
                };
                Publisher _p9EdgeEntertainment = new()
                {
                    
                    PublisherName = "Edge Entertainment"
                };
                Publisher _p10Devir = new()
                {
                    
                    PublisherName = "Devir"
                };
                Publisher _p11ErgoLudir = new()
                {
                    
                    PublisherName = "Ergo Ludo Editions"
                };
                Publisher _p12FoxInTheBox = new()
                {
                    
                    PublisherName = "Fox in the Box"
                };
                Publisher _p13FantasyFlight = new()
                {
                    
                    PublisherName = "Fantasy Flight Games"
                };
                Publisher _p14NexusEditrice = new()
                {
                    
                    PublisherName = "Nexus Editrice"
                };
                Publisher _p15Ubik = new()
                {
                    
                    PublisherName = "Ubik"
                };
                Publisher _p16SPI = new()
                {
                    
                    PublisherName = "SPI (Simulations Publications, Inc.)"
                };

                //define games using join entity
                /*                Game game1 = new()
                                {
                                    GameId = 1,
                                    Name = "Hannibal: Rome vs. Carthage",
                                    Category = c1,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 1, GameId = 1 }, new() { PublisherId = 2, GameId = 1 } },
                                    PublicationYear = 1996,
                                    ImageLink = "https://boardgamegeek.com/image/774569/the-great-battles-of-alexander-deluxe-edition",
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game2 = new()
                                {
                                    GameId = 2,
                                    Name = "Sword of Rome: Conquest of Italy, 362-272 BC",
                                    Category = c1,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 3, GameId = 2 } },
                                    PublicationYear = 2004,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game3 = new()
                                {
                                    GameId = 3,
                                    Name = "The Great Battles of Alexander: Deluxe Edition",
                                    Category = c1,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 3, GameId = 3 } },
                                    PublicationYear = 1995,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game4 = new()
                                {
                                    GameId = 4,
                                    Name = "Empires in Arms",
                                    Category = c2,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 1, GameId = 4 }, new() { PublisherId = 4, GameId = 4 } },
                                    PublicationYear = 1983,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game5 = new()
                                {
                                    GameId = 5,
                                    Name = "The Napoleonic Wars (Second Edition)",
                                    Category = c2,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 3, GameId = 5 } },
                                    PublicationYear = 2008,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game6 = new()
                                {
                                    GameId = 6,
                                    Name = "Age of Napoleon",
                                    Category = c2,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 6, GameId = 6 }, new() { PublisherId = 7, GameId = 6 } },
                                    PublicationYear = 2003,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game7 = new()
                                {
                                    GameId = 7,
                                    Name = "War and Peace",
                                    Category = c2,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 1, GameId = 7 } },
                                    PublicationYear = 1980,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game8 = new()
                                {
                                    GameId = 8,
                                    Name = "Memoir '44",
                                    Category = c3,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 7, GameId = 8 }, new() { PublisherId = 8, GameId = 8 }, new() { PublisherId = 9, GameId = 8 } },
                                    PublicationYear = 2004,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game9 = new()
                                {
                                    GameId = 9,
                                    Name = "Combat Commander: Europe",
                                    Category = c3,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 3, GameId = 9 }, new() { PublisherId = 10, GameId = 9 } },
                                    PublicationYear = 2006,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game10 = new()
                                {
                                    GameId = 10,
                                    Name = "Churchill",
                                    Category = c3,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 3, GameId = 10 }, new() { PublisherId = 10, GameId = 10 }, new() { PublisherId = 11, GameId = 10 }, new() { PublisherId = 12, GameId = 10 } },
                                    PublicationYear = 2004,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game11 = new()
                                {
                                    GameId = 11,
                                    Name = "Tide of Iron",
                                    Category = c3,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 13, GameId = 11 }, new() { PublisherId = 9, GameId = 11 }, new() { PublisherId = 14, GameId = 11 }, new() { PublisherId = 15, GameId = 11 } },
                                    PublicationYear = 2007,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game12 = new()
                                {
                                    GameId = 12,
                                    Name = "Panzergruppe Guderian",
                                    Category = c3,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 1, GameId = 12 }, new() { PublisherId = 16, GameId = 12 } },
                                    PublicationYear = 1976,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                                Game game13 = new()
                                {
                                    GameId = 13,
                                    Name = "Triumph & Tragedy: European Balance of Power 1936-1945",
                                    Category = c3,
                                    PublisherGames = new List<PublisherGame> { new() { PublisherId = 3, GameId = 13 } },
                                    PublicationYear = 2015,
                                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                                };
                */
                Game game1 = new()
                {
                    
                    Name = "Hannibal: Rome vs. Carthage",
                    Category = c1,
                    Publishers = [_p1AvalonHill, _p2ValleyGames],
                    PublicationYear = 1996,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game2 = new()
                {
                    
                    Name = "Sword of Rome: Conquest of Italy, 362-272 BC",
                    Category = c1,
                    Publishers = [_p3GMTGames],
                    PublicationYear = 2004,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game3 = new()
                {
                    
                    Name = "The Great Battles of Alexander: Deluxe Edition",
                    Category = c1,
                    Publishers = [_p3GMTGames],
                    PublicationYear = 1995,
                    ImageLink = "https://cf.geekdo-images.com/suTjL2RCVl12Mwftjfon-Q__imagepagezoom/img/bE7Dp_LJJxF1lMWOevHvFJP5Dys=/fit-in/1200x900/filters:no_upscale():strip_icc()/pic774569.jpg",
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game4 = new()
                {
                    
                    Name = "Empires in Arms",
                    Category = c2,
                    Publishers = [_p1AvalonHill, _p4AustralianDesignGroup],
                    PublicationYear = 1983,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game5 = new()
                {
                    
                    Name = "The Napoleonic Wars (Second Edition)",
                    Category = c2,
                    Publishers = [_p3GMTGames],
                    PublicationYear = 2008,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game6 = new()
                {
                    
                    Name = "Age of Napoleon",
                    Category = c2,
                    Publishers = [_p5MayfairGames, _p6Phalanx, _p7DaysOfWonder],
                    PublicationYear = 2003,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game7 = new()
                {
                    
                    Name = "War and Peace",
                    Category = c2,
                    Publishers = [_p1AvalonHill],
                    PublicationYear = 1980,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game8 = new()
                {
                    
                    Name = "Memoir '44",
                    Category = c3,
                    Publishers = [_p7DaysOfWonder, _p8ADCBlackfire, _p9EdgeEntertainment],
                    PublicationYear = 2004,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game9 = new()
                {
                    
                    Name = "Combat Commander: Europe",
                    Category = c3,
                    Publishers = [_p3GMTGames, _p10Devir],
                    PublicationYear = 2006,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game10 = new()
                {
                    
                    Name = "Churchill",
                    Category = c3,
                    Publishers = [_p3GMTGames, _p10Devir, _p11ErgoLudir, _p12FoxInTheBox],
                    PublicationYear = 2004,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game11 = new()
                {
                    
                    Name = "Tide of Iron",
                    Category = c3,
                    Publishers = [_p13FantasyFlight, _p9EdgeEntertainment, _p14NexusEditrice, _p15Ubik],
                    PublicationYear = 2007,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game12 = new()
                {
                    
                    Name = "Panzergruppe Guderian",
                    Category = c3,
                    Publishers = [_p1AvalonHill, _p16SPI],
                    PublicationYear = 1976,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };
                Game game13 = new()
                {
                    
                    Name = "Triumph & Tragedy: European Balance of Power 1936-1945",
                    Category = c3,
                    Publishers = [_p3GMTGames],
                    PublicationYear = 2015,
                    GameDescription = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Sit amet consectetur adipiscing elit quisque faucibus ex. Adipiscing elit quisque faucibus ex sapien vitae pellentesque."
                };


                context.Products.AddRange
                (
                    new Product
                    {
                     Game = game1,
                     Name = game1.Name,
                     Category = c1,
                     ProductOwner = po1,
                     Price = 14.99m
                    },
                    new Product
                    {
                     Game = game2,
                     Name = game2.Name,
                     Category = c1,
                     ProductOwner = po2,
                     Price = 19.99m
                    },
                    new Product
                    {
                     Game = game3,
                     Name = game3.Name,
                     Category = c1,
                     ProductOwner = po1,
                     Price = 24.99m
                    },
                    new Product
                    {
                     Game = game4,
                     Name = game4.Name,
                     Category = c2,
                     ProductOwner = po2,
                     Price = 29.99m
                    },
                    new Product
                    {
                     Game = game5,
                     Name = game5.Name,
                     Category = c2,
                     ProductOwner = po1,
                     Price = 34.99m
                    },
                    new Product
                    {
                     Game = game6,
                     Name = game6.Name,
                     Category = c2,
                     ProductOwner = po2,
                     Price = 39.99m
                    },
                    new Product
                    {
                     Game = game7,
                     Name = game7.Name,
                     Category = c2,
                     ProductOwner = po1,
                     Price = 44.99m
                    },
                    new Product
                    {
                     Game = game8,
                     Name = game8.Name,
                     Category = c3,
                     ProductOwner = po2,
                     Price = 49.99m
                    },
                    new Product
                    {
                     Game = game9,
                     Name = game9.Name,
                     Category = c3,
                     ProductOwner = po1,
                     Price = 54.99m
                    },
                    new Product
                    {
                     Game = game10,
                     Name = game10.Name,
                     Category = c3,
                     ProductOwner = po2,
                     Price = 59.99m
                    },
                    new Product
                    {
                     Game = game11,
                     Name = game11.Name,
                     Category = c3,
                     ProductOwner = po1,
                     Price = 64.99m
                    },
                    new Product
                    {
                     Game = game12,
                     Name = game12.Name,
                     Category = c3,
                     ProductOwner = po2,
                     Price = 69.99m
                    },
                    new Product
                    {
                     Game = game13,
                     Name = game13.Name,
                     Category = c3,
                     ProductOwner = po1,
                     Price = 74.99m
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
