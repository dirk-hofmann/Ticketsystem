namespace Ticketsystem.Migrations
{
    using Models;
    using System;
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

            context.Projects.AddOrUpdate(
                new Project { Title = "Projekt 1" },
                new Project { Title = "Projekt 2" }
            );

            context.SaveChanges();

            context.Tickets.AddOrUpdate(
                x => x.Title,
                new Ticket
                {
                    Title = "Ticket 1",
                    Description = "Mein erstes Ticket für Projekt 1",
                    CreationDate = DateTime.Now,
                    Project = context.Projects.Where(x => x.ProjectId == 1).First()
                },
                new Ticket
                {
                    Title = "Ticket 2",
                    Description = "Mein zweites Ticket für Projekt 1",
                    CreationDate = DateTime.Now,
                    Project = context.Projects.Where(x => x.ProjectId == 1).First()
                },
                new Ticket
                {
                    Title = "Ticket 1",
                    Description = "Mein erstes Ticket für Projekt 2",
                    CreationDate = DateTime.Now,
                    Project = context.Projects.Where(x => x.ProjectId == 2).First()
                }
            );
            
        }
    }
}
