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
            if(!context.Providers.Any()){
                context.Providers.AddRange(
                     new Provider
                {
                    TradeName = "TradeName1",
                    TID = "12345678901",
                    PhoneNumber = "987654321",
                    Email = "provider1@example.com",
                    Website = "http://www.provider1.com",
                    Address = "Address 1",
                    Country = "Peru",
                    AnualRevenue = 500000.00m,
                    LastEditedDate = DateTime.Now
                },
                new Provider
                {
                    TradeName = "TradeName2",
                    TID = "23456789012",
                    PhoneNumber = "987654322",
                    Email = "provider2@example.com",
                    Website = "http://www.provider2.com",
                    Address = "Address 2",
                    Country = "Peru",
                    AnualRevenue = 750000.00m,
                    LastEditedDate = DateTime.Now
                },
                new Provider
                {
                    TradeName = "TradeName3",
                    TID = "34567890123",
                    PhoneNumber = "987654323",
                    Email = "provider3@example.com",
                    Website = "http://www.provider3.com",
                    Address = "Address 3",
                    Country = "Peru",
                    AnualRevenue = 1000000.00m,
                    LastEditedDate = DateTime.Now
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