using Microsoft.AspNetCore.Identity;
using ShootingEventSystemWebAPI.Entities;

namespace ShootingEventSystemWebAPI
{
    public class Seeder
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public Seeder(TournamentDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
        public void Seed() 
        {
            if (!_dbContext.Database.CanConnect()) return;
            if (_dbContext.Users.Any()) return;

            _dbContext.Users.Add(GetUserSample());
            _dbContext.Clubs.AddRange(GetClubs());
            _dbContext.Competitions.AddRange(GetCompetitions());
            _dbContext.SaveChanges();
        }

        private User GetUserSample()
        {
            
            User SampleUser = new User()
            {
                Name = "Admin",
                Surname = "Admin",
                Email = "admin@wp.pl",
                IsActive = true,
                IsAdmin = true,
                PhoneNumber = "1234567890",
            };

            SampleUser.Password = _passwordHasher.HashPassword(SampleUser, "password");

            return SampleUser;

        }

        private List<Club> GetClubs() 
        {
            List<Club> Clubs = new List<Club>()
            {
                new Club()
                {
                    Name = "MKS LOK Rybnik",
                    Description = "",
                    PhoneNumber= "+48 123 456 111",
                    Address = new Address()
                    {
                        Country = "Poland",
                        City = "Rybnik",
                        Street = "Prosta",
                        BuildingNumber = "11",
                        PostalCode = "44-200"

                    }
                },
                new Club()
                {
                    Name = "TS Temida",
                    Description = "",
                    PhoneNumber= "+48 123 456 222",
                    Address = new Address()
                    {
                        Country = "Poland",
                        City = "Zabrze",
                        Street = " Księdza Pawła Janika",
                        BuildingNumber = "12",
                        PostalCode = "41-806"

                    }
                },
                new Club()
                {
                    Name = "KS Amator",
                    Description = "",
                    PhoneNumber= "+48 123 456 333",
                    Address = new Address()
                    {
                        Country = "Poland",
                        City = "Warszawa",
                        Street = "Jerzego Waldorffa",
                        BuildingNumber = "23",
                        PostalCode = "01-494"

                    }
                }
            };

            return Clubs;
        }

        private List<Competition> GetCompetitions()
        {
            var competitions = new List<Competition>
            {
                new Competition
                {
                    Name = "10m Air Rifle Men",
                    Description = "Men's 10 meter air rifle event",
                    MaxScore = 654.0m
                },
                new Competition
                {
                    Name = "10m Air Rifle Women",
                    Description = "Women's 10 meter air rifle event",
                    MaxScore = 654.0m
                },
                new Competition
                {
                    Name = "10m Air Pistol Men",
                    Description = "Men's 10 meter air pistol event",
                    MaxScore = 654.0m
                },
                new Competition
                {
                    Name = "10m Air Pistol Women",
                    Description = "Women's 10 meter air pistol event",
                    MaxScore = 654.0m
                },
                new Competition
                {
                    Name = "25m Pistol Women",
                    Description = "Women's 25 meter pistol event",
                    MaxScore = 600.0m
                },
                new Competition
                {
                    Name = "25m Rapid Fire Pistol Men",
                    Description = "Men's 25 meter rapid fire pistol event",
                    MaxScore = 600.0m
                },
                new Competition
                {
                    Name = "50m Rifle 3 Positions Men",
                    Description = "Men's 50 meter rifle three positions event",
                    MaxScore = 654.0m
                },
                new Competition
                {
                    Name = "50m Rifle 3 Positions Women",
                    Description = "Women's 50 meter rifle three positions event",
                    MaxScore = 654.0m
                },
                new Competition
                {
                    Name = "Trap Men",
                    Description = "Men's trap shooting event",
                    MaxScore = 125.0m
                },
                new Competition
                {
                    Name = "Trap Women",
                    Description = "Women's trap shooting event",
                    MaxScore = 125.0m
                },
                new Competition
                {
                    Name = "Skeet Men",
                    Description = "Men's skeet shooting event",
                    MaxScore = 125.0m
                },
                new Competition
                {
                    Name = "Skeet Women",
                    Description = "Women's skeet shooting event",
                    MaxScore = 125.0m
                }
            };
            return competitions;
        }

       
    }

}
