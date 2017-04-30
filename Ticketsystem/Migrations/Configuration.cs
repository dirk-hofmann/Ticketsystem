namespace Ticketsystem.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ticketsystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Ticketsystem.Models.ApplicationDbContext";
        }

        protected override void Seed(Ticketsystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            #region Create Companies

            context.Companies.AddOrUpdate(
                x => x.Name,
                new Company { Name = "BaerTec" },
                new Company { Name = "Cartman" }
            );

            context.SaveChanges();

            #endregion

            #region Create Roles
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Editor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Editor" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Customer" };

                manager.Create(role);
            }

            #endregion

            #region Create Users
            if (!context.Users.Any(u => u.UserName == "cgmbaer@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "cgmbaer@gmail.com", Email = "cgmbaer@gmail.com" };

                manager.Create(user, "ChangeItAsap!");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "dirkhofmann@outlook.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser {
                    UserName = "dirkhofmann@outlook.com",
                    Email = "dirkhofmann@outlook.com",
                    Company = context.Companies.Where(x => x.Name == "BaerTec").First()
                };

                manager.Create(user, "ChangeItAsap!");
                manager.AddToRole(user.Id, "Customer");
            }

            #endregion

            #region Create Projects

            context.Projects.AddOrUpdate(
                x => x.Title,
                new Project {
                    Title = "Projekt BaerTec",
                    Company = context.Companies.Where(x => x.Name == "BaerTec").First(),
                    CreationDate = DateTime.Now,
                    Editors = new List<ApplicationUser>()
                    {
                       context.Users.Where(x => x.UserName == "cgmbaer@gmail.com").First()
                    }
                },
                new Project {
                    Title = "Projekt 2",
                    CreationDate = DateTime.Now
                }
            );

            context.SaveChanges();

            #endregion

            #region Create Tickets
            context.Tickets.AddOrUpdate(
                x => x.Title,
                new Ticket
                {
                    Title = "Ticket 1",
                    Description = "Mein erstes Ticket für Projekt 1",
                    CreationDate = DateTime.Now,
                    Project = context.Projects.Where(x => x.ProjectId == 1).First(),
                    Status = Models.TicketStatus.Ordered
                },
                new Ticket
                {
                    Title = "Ticket 2",
                    Description = "Mein zweites Ticket für Projekt 1",
                    CreationDate = DateTime.Now,
                    Project = context.Projects.Where(x => x.ProjectId == 1).First(),
                    Status = TicketStatus.WaitingForResponse
                },
                new Ticket
                {
                    Title = "Ticket 3",
                    Description = "Mein erstes Ticket für Projekt 2",
                    CreationDate = DateTime.Now,
                    Project = context.Projects.Where(x => x.ProjectId == 2).First()
                }
            );

            context.SaveChanges();

            #endregion

            #region Create Messages

            context.Messages.AddOrUpdate(
                x => x.Title,
                new Message
                {
                    Title = "Erste Nachricht",
                    Text = "Das ist die erste NAchricht.",
                    CreationDate = DateTime.Now,
                    Creator = context.Users.Where(x => x.UserName == "cgmbaer@gmail.com").First(),
                    Ticket = context.Tickets.Where(x => x.Title == "Ticket 1").First()
                },
                new Message
                {
                    Title = "Zweite Nachricht",
                    Text = "Das ist die zweite Nachricht.",
                    CreationDate = DateTime.Now,
                    Creator = context.Users.Where(x => x.UserName == "cgmbaer@gmail.com").First(),
                    Ticket = context.Tickets.Where(x => x.Title == "Ticket 1").First()
                }
            );

            context.SaveChanges();

            #endregion

        }
    }
}
