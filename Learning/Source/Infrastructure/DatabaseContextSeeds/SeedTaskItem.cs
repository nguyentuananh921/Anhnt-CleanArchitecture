using Domain.Entities;
using Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContextSeeds
{
    public static class SeedTaskItem
    {
        /// <summary>
        /// For Data forllow instruction Using 
        /// https://www.mockaroo.com/
        /// To create SampleData
        /// https://codewithmukesh.com/blog/jquery-datatable-in-aspnet-core/
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task SeedTaskItemDataAsync(ApplicationDbContext context)
        {
            if (context.TaskItems.Any())
            {
                return;   // DB has been seeded
            }
            context.TaskItems.AddRange(
                new TaskItem { Id = 1, TaskName = "Feed the dog", IsCompleted = true },
                new TaskItem { Id = 2, TaskName = "Catch the Fish", IsCompleted = false },
                new TaskItem { Id = 3, TaskName = "Fix the car", IsCompleted = true },
                new TaskItem { Id = 4, TaskName = "Design the house", IsCompleted = false }

             );
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
