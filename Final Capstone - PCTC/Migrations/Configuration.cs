namespace Final_Capstone___PCTC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Final_Capstone___PCTC.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Final_Capstone___PCTC.Models.PCTCContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Final_Capstone___PCTC.Models.PCTCContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.PCTCUsers.AddOrUpdate(u => u.UserId,
                new PCTCUser() { FirstName = "Brittney", LastName = "Corona", UserName = "brit1", UserId = 1},
                new PCTCUser() { FirstName = "Zach", LastName = "Marshall", UserName = "ZachM", UserId = 2 }
                );

            context.SaveChanges();
            var query = from user in context.PCTCUsers where user.UserName == "brit1" select user;
            PCTCUser user1 = query.Single();

            context.TimeCapsules.AddOrUpdate(t => t.TCId,
                new TimeCapsule() { Name = "TC Name", Date = DateTime.Now, TCId = 1, UserId =  1, ChildImg = "test" },
                new TimeCapsule() { Name = "Test Two", Date = DateTime.Now, TCId = 2, UserId = 2, ChildImg = "test2" }
                );
            context.SaveChanges();

            context.BooksData.AddOrUpdate(bd => bd.BookId,
                new BookData() { Author = "Author Name", BookId = 1, Title = "Title here", TCId = 1 },
                new BookData() { Author = "Something something", BookId = 2, Title = "Something Blah", TCId = 1 }
                );
        }
    }
}
