﻿using Domain.Entities;
using Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContextSeeds
{
    public static class SeedContact
    {
        public static async Task SeedContactDataAsync(ApplicationDbContext context)
        {
            if (context.Contacts.Any())
            {
                return;   // DB has been seeded
            }
            context.Contacts.AddRange(
                new Contact
                {
                    Name = "Debra Garcia",
                    Address = "1234 Main St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "debra@example.com"
                },
                new Contact
                {
                    Name = "Thorsten Weinrich",
                    Address = "5678 1st Ave W",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "thorsten@example.com"
                },
             new Contact
             {
                 Name = "Yuhong Li",
                 Address = "9012 State st",
                 City = "Redmond",
                 State = "WA",
                 Zip = "10999",
                 Email = "yuhong@example.com"
             },
             new Contact
             {
                 Name = "Jon Orton",
                 Address = "3456 Maple St",
                 City = "Redmond",
                 State = "WA",
                 Zip = "10999",
                 Email = "jon@example.com"
             },
             new Contact
             {
                 Name = "Diliana Alexieva-Bosseva",
                 Address = "7890 2nd Ave E",
                 City = "Redmond",
                 State = "WA",
                 Zip = "10999",
                 Email = "diliana@example.com"
             }
             );
            context.SaveChanges();
            await context.SaveChangesAsync();
        }
    }
}
