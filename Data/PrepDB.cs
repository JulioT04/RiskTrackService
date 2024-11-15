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
                    TID = "12345678901",
                    PhoneNumber = "31201234567",
                    Email = "info@peijnenburgholding.nl",
                    Website = "http://www.peijnenburgholding.nl",
                    Address = "Dam Square 1, 1012 JS Amsterdam, Netherlands",
                    Country = "Argentina",
                    AnualRevenue = 120000050,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "ADVANCED TECHNOLOGIES HOLDING COMPANY",
                    TID = "C987654321",
                    PhoneNumber = "80055501991",
                    Email = "contact@advancedtech.com",
                    Website = "http://www.advancedtech.com",
                    Address = "123 Silicon Valley, CA 94025, USA",
                    Country = "Chile",
                    AnualRevenue = 250000075,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "NISHAN ENGINEERS (PVT) LIMITED",
                    TID = "32165498745",
                    PhoneNumber = "924212345678",
                    Email = "sales@nishanengineers.pk",
                    Website = "http://www.nishanengineers.pk",
                    Address = "Mall Road, Lahore, Pakistan",
                    Country = "Colombia",
                    AnualRevenue = 80000025,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "CAIRO CONSULT",
                    TID = "98732165479",
                    PhoneNumber = "20212345678",
                    Email = "info@cairoconsult.com",
                    Website = "http://www.cairoconsult.com",
                    Address = "Tahrir Square, Cairo, Egypt",
                    Country = "Argentina",
                    AnualRevenue = 60000040,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "SEAR TOWER LIMITED",
                    TID = "32198765463",
                    PhoneNumber = "442079460958",
                    Email = "info@seartower.co.uk",
                    Website = "http://www.seartower.co.uk",
                    Address = "1 Canada Square, London, UK",
                    Country = "Chile",
                    AnualRevenue = 220000090,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "INTER-TECH TECH LTD",
                    TID = "65478932123",
                    PhoneNumber = "81312345678",
                    Email = "info@inter-tech.jp",
                    Website = "http://www.inter-tech.jp",
                    Address = "Shibuya Crossing, Tokyo, Japan",
                    Country = "Colombia",
                    AnualRevenue = 170000035,
                    LastEditedDate = DateTime.Now,
                    UserId = context.Users.First().Id
                },
                new Provider
                {
                    TradeName = "SEA TO SEA GLOBAL TRADING, LLC",
                    TID = "98745612378",
                    PhoneNumber = "42121234567",
                    Email = "contact@seatosetrading.com",
                    Website = "http://www.seatosetrading.com",
                    Address = "Broadway, New York, USA",
                    Country = "Argentina",
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