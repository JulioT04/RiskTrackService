using Microsoft.EntityFrameworkCore;
using RiskTrack.Models;

namespace RiskTrack.Data {
    public static class PrepDB{
        public static void PrepPopulate(IApplicationBuilder app, bool isProd) 
        {
            using(var serviceScope = app.ApplicationServices.CreateScope()){
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }
       private static void SeedData(AppDbContext context, bool isProd){
            if(isProd){
                try {
                    context.Database.Migrate();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            if(!context.Users.Any()){
                context.Users.AddRange(
                new User
                {
                    UserName = "SWarthon",
                    Email = "sebastian.warthon@pe.ey.com",
                    Password = "1234",
                },
                new User
                {
                    UserName = "FEspinoza",
                    Email = "fabrizio.espinoza@pe.ey.com",
                    Password = "4321",
                }
                );
                context.SaveChanges();
            }
            else{
                Console.WriteLine("There's already data");
            }

            if(!context.Providers.Any()){
                context.Providers.AddRange(
                new Provider
                {
                    TradeName = "A.A.M. PEIJNENBURG HOLDING B.V.",
                    TID = "B123456789",
                    PhoneNumber = "+31 20 123 4567",
                    Email = "info@peijnenburgholding.nl",
                    Website = "http://www.peijnenburgholding.nl",
                    Address = "Dam Square 1, 1012 JS Amsterdam, Netherlands",
                    Country = "Netherlands",
                    AnualRevenue = 120000050,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "ADVANCED TECHNOLOGIES HOLDING COMPANY",
                    TID = "C987654321",
                    PhoneNumber = "+1 800 555 0199",
                    Email = "contact@advancedtech.com",
                    Website = "http://www.advancedtech.com",
                    Address = "123 Silicon Valley, CA 94025, USA",
                    Country = "USA",
                    AnualRevenue = 250000075,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "NISHAN ENGINEERS (PVT) LIMITED",
                    TID = "E321654987",
                    PhoneNumber = "+92 42 1234 5678",
                    Email = "sales@nishanengineers.pk",
                    Website = "http://www.nishanengineers.pk",
                    Address = "Mall Road, Lahore, Pakistan",
                    Country = "Pakistan",
                    AnualRevenue = 80000025,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "CAIRO CONSULT",
                    TID = "G987321654",
                    PhoneNumber = "+20 2 1234 5678",
                    Email = "info@cairoconsult.com",
                    Website = "http://www.cairoconsult.com",
                    Address = "Tahrir Square, Cairo, Egypt",
                    Country = "Egypt",
                    AnualRevenue = 60000040,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "SEAR TOWER LIMITED",
                    TID = "H321987654",
                    PhoneNumber = "+44 20 7946 0958",
                    Email = "info@seartower.co.uk",
                    Website = "http://www.seartower.co.uk",
                    Address = "1 Canada Square, London, UK",
                    Country = "UK",
                    AnualRevenue = 220000090,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "INTER-TECH TECH LTD",
                    TID = "I654789321",
                    PhoneNumber = "+81 3 1234 5678",
                    Email = "info@inter-tech.jp",
                    Website = "http://www.inter-tech.jp",
                    Address = "Shibuya Crossing, Tokyo, Japan",
                    Country = "Japan",
                    AnualRevenue = 170000035,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "SEA TO SEA GLOBAL TRADING, LLC",
                    TID = "J987456123",
                    PhoneNumber = "+1 212 123 4567",
                    Email = "contact@seatosetrading.com",
                    Website = "http://www.seatosetrading.com",
                    Address = "Broadway, New York, USA",
                    Country = "USA",
                    AnualRevenue = 270000050,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                }
                );
                context.SaveChanges();
            }
            else{
                Console.WriteLine("There's already data");
            }
        }
    
    
    }
}