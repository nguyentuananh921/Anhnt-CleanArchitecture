using Domain.Entities;
using Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContextSeeds
{
    public static class SeedCar
    {
        /// <summary>
        /// For Data forllow instruction Using 
        /// https://www.mockaroo.com/        
        /// </summary>        
        public static async Task SeedCarDataAsync(ApplicationDbContext context)
        {
            if (context.Cars.Any())
            {
                return;   // DB has been seeded
            }
            context.Cars.AddRange(
                new Car { Id=1,Name="Lexus"},              
                new Car { Id = 2, Name = "Rolls-Royce" },
                new Car { Id = 3, Name = "Lexus" },
                new Car { Id = 4, Name = "Kia" },
                new Car { Id = 5, Name = "Mercury" },
                new Car { Id = 6, Name = "Chevrolet" },
                new Car { Id = 7, Name = "Volkswagen" },
                new Car { Id = 8, Name = "BMW" },
                new Car { Id = 9, Name = "Ford" },
                new Car { Id = 10, Name = "Mercedes-Benz" }
             );
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
