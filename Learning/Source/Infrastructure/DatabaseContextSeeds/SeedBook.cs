using Domain.Entities;
using Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContextSeeds
{
    public static class SeedBook
    {
        public static async Task SeedBookDataAsync(ApplicationDbContext context)
        {
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }
            context.Books.AddRange(
                new Book {Name= "The Lord of the Rings",ISBN= "99921-58-10-7",AuthorName= "J. R. R. Tolkien" },
                new Book { Name = "The Da Vinci Code", ISBN = "0-385-50420-9", AuthorName = "Dan Brown" },
                new Book { Name = "Angels & Demons", ISBN = "0-671-02735-2", AuthorName = "Dan Brown" }
             );
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
