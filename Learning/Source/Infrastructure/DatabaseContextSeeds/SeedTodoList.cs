using Domain.Entities;
using Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContextSeeds
{
    public static class SeedTodoList
    {
        public static async Task SeedTodoListDataAsync(ApplicationDbContext context)
        {
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }
            context.TodoLists.Add(new TodoList
            {
                Title = "Shopping",
                //Colour = Colour.Blue,
                Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
            });
            await context.SaveChangesAsync();
        }
    }
}
