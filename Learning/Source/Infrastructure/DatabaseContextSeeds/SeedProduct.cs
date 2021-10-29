using Domain.Entities;
using Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContextSeeds
{
    public static class SeedProduct
    {
        /// <summary>
        /// For Data forllow instruction Using 
        /// https://www.mockaroo.com/
        /// To create SampleData
        /// https://codewithmukesh.com/blog/jquery-datatable-in-aspnet-core/
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task SeedProductDataAsync(ApplicationDbContext context)
        {
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }
            context.Products.AddRange(
                new Product { Id = 1, Name = "Chicken - Tenderloin", Rate = 8 },
                new Product { Id = 2, Name = "Yogurt - Cherry, 175 Gr", Rate = 2 },
                new Product { Id = 3, Name = "Chocolate - Dark", Rate = 4 },
                new Product { Id = 4, Name = "Onions - Pearl", Rate = 3 },
                new Product { Id = 5, Name = "Ice Cream - Life Savers", Rate = 14 },
                new Product { Id = 6, Name = "Gingerale - Schweppes, 355 Ml", Rate = 15 },
                new Product { Id = 7, Name = "Absolut Citron", Rate = 20 },
                new Product { Id = 8, Name = "Chips Potato Swt Chilli Sour", Rate = 5 },
                new Product { Id = 9, Name = "Spring Roll Veg Mini", Rate = 19 },
                new Product { Id = 10, Name = "Cloves - Whole", Rate = 9 },
                new Product { Id = 11, Name = "Potatoes - Purple, Organic", Rate = 7 },
                new Product { Id = 12, Name = "Wheat - Soft Kernal Of Wheat", Rate = 11 },
                new Product { Id = 13, Name = "Sauce - Hoisin", Rate = 9 },
                new Product { Id = 14, Name = "Pepper - Pablano", Rate = 6 },
                new Product { Id = 15, Name = "Wine - Bouchard La Vignee Pinot", Rate = 7 },
                new Product { Id = 16, Name = "Wine - Guy Sage Touraine", Rate = 5 },
                new Product { Id = 17, Name = "Ostrich - Fan Fillet", Rate = 17 },
                new Product { Id = 18, Name = "Beef - Top Sirloin", Rate = 11 },
                new Product { Id = 19, Name = "Juice - Apple, 1.36l", Rate = 11 },
                new Product { Id = 20, Name = "Sobe - Tropical Energy", Rate = 17 },
                new Product { Id = 21, Name = "Rice - Aborio", Rate = 3 },
                new Product { Id = 22, Name = "Beef - Ox Tongue, Pickled", Rate = 9 },
                new Product { Id = 23, Name = "Red Pepper Paste", Rate = 10 },
                new Product { Id = 24, Name = "Onions - Green", Rate = 4 },
                new Product { Id = 25, Name = "Lid - 10,12,16 Oz", Rate = 2 },
                new Product { Id = 26, Name = "Wine - White, French Cross", Rate = 3 },
                new Product { Id = 27, Name = "Pastry - Choclate Baked", Rate = 2 },
                new Product { Id = 28, Name = "Tea - Lemon Scented", Rate = 19 },
                new Product { Id = 29, Name = "Soup - Beef, Base Mix", Rate = 18 },
                new Product { Id = 30, Name = "Ecolab - Mikroklene 4/4 L", Rate = 2 },
                new Product { Id = 31, Name = "Flounder - Fresh", Rate = 6 },
                new Product { Id = 32, Name = "Muffins - Assorted", Rate = 12 },
                new Product { Id = 33, Name = "Truffle Cups - Red", Rate = 11 },
                new Product { Id = 34, Name = "Table Cloth 72x144 White", Rate = 17 },
                new Product { Id = 35, Name = "Initation Crab Meat", Rate = 17 },
                new Product { Id = 36, Name = "Beef - Top Sirloin - Aaa", Rate = 5 },
                new Product { Id = 37, Name = "Wine - Ruffino Chianti", Rate = 8 },
                new Product { Id = 38, Name = "Emulsifier", Rate = 20 },
                new Product { Id = 39, Name = "Graham Cracker Mix", Rate = 1 },
                new Product { Id = 40, Name = "Lamb Shoulder Boneless Nz", Rate = 19 },
                new Product { Id = 41, Name = "Table Cloth - 53x69 Colour", Rate = 12 },
                new Product { Id = 42, Name = "Shiratamako - Rice Flour", Rate = 17 },
                new Product { Id = 43, Name = "Lobster - Baby, Boiled", Rate = 11 },
                new Product { Id = 44, Name = "Cheese - Valancey", Rate = 15 },
                new Product { Id = 45, Name = "Turkey - Breast, Bone - In", Rate = 15 },
                new Product { Id = 46, Name = "Eggplant Oriental", Rate = 8 },
                new Product { Id = 47, Name = "Wine - Magnotta, Merlot Sr Vqa", Rate = 18 },
                new Product { Id = 48, Name = "Pastry - Banana Tea Loaf", Rate = 15 },
                new Product { Id = 49, Name = "Truffle Cups - Red", Rate = 10 },
                new Product { Id = 50, Name = "Island Oasis - Banana Daiquiri", Rate = 10 }
             );
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
