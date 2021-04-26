using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Kanban.Models;

namespace Kanban.Data
{
    public class Initialize
    {
        public static void Initialise(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait(TimeSpan.FromSeconds(5));
                roleManager.CreateAsync(new IdentityRole("Member")).Wait(TimeSpan.FromSeconds(5));
                roleManager.CreateAsync(new IdentityRole("Obs")).Wait(TimeSpan.FromSeconds(5));

            }

            if (!context.Boards.Any())
            {
                var kBoard = new Board();
                kBoard.Id = 1;
                kBoard.BoardName = "Kanban Board";
                context.Add(kBoard);

                var column1 = new Column(1, "To do", kBoard.Id);
                var column2 = new Column(2, "Doing", kBoard.Id);
                var column3 = new Column(3, "Done", kBoard.Id);

                List<Column> Columns = new List<Column>
                {
                    column1, column2, column3
                };
                foreach (var c in Columns)
                {
                    context.Columns.Add(c);
                }

                context.SaveChanges();
            }

        }
    }
}
