namespace ClassroomFollowup.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using ClassroomFollowup.Models;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassroomFollowup.Models.ClassroomFollowupContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClassroomFollowup.Models.ClassroomFollowupContext context)
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

            context.Followups.AddOrUpdate(f => f.ID,
                new Followup() { ID = 1, Date = DateTime.Now, Trainer = "Olivier Ceressia", Training = "Front-end developer", Description="Tout se passe bien" },
                new Followup() { ID = 2, Date = DateTime.Now, Trainer = "Nicolas Bauwens", Training = "Front-end developer", Description="On commence Vue.js" });

        }
    }
}
