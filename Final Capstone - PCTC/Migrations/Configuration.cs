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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Final_Capstone___PCTC.Models.PCTCContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.PCTCUsers.AddOrUpdate(u => u.UserId,
                new PCTCUser() { FirstName = "Brittney", LastName = "Corona", UserName = "brit1", UserId = 1}
                );

            context.SaveChanges();
            var query = from user in context.PCTCUsers where user.UserName == "brit1" select user;
            PCTCUser user1 = query.Single();

            context.TimeCapsules.AddOrUpdate(t => t.TCId,
                new TimeCapsule() { Name = "Example TimeCapsule Name", Date = DateTime.Now, TCId = 1, UserId =  1, ChildImg = "test" },
                new TimeCapsule() { Name = "Nashville Software School", Date = DateTime.Now, TCId = 2, UserId = 1, ChildImg = "test2" }
                );
            context.SaveChanges();

            context.BooksData.AddOrUpdate(bd => bd.BookId,
                new BookData() { Author = "J.K. Rowling", BookId = 1, Title = "Harry Potter and the Sorcerer's Stone", TCId = 1, BookCoverImg = "http://images.contentful.com/7h71s48744nc/xL3Qo6cMYEc9q3zH4RZn8c/8b25aaaea57999cc602ac2b9c88ed8db/harry-potter-and-the-sorcerers-stone-cover-image" },
                new BookData() { Author = "J.K. Rowling", BookId = 2, Title = "Fantastic Beasts and Where to Find Them Book Cover", TCId = 1, BookCoverImg = "http://cdn.collider.com/wp-content/uploads/fantastic-beasts-and-where-to-find-them-book.jpg" },
                new BookData() { Author = "Mark Myers", Title = "Smarter Way To Learn JavaScript", TCId = 2, BookCoverImg = "http://ecx.images-amazon.com/images/I/51JwcqaSYPL._SX348_BO1,204,203,200_.jpg" },
                new BookData() { Author = "Mark Myers", Title = "Smarter Way To Learn Html & CSS", TCId = 2, BookCoverImg = "http://ecx.images-amazon.com/images/I/51JvNSxkdTL._SX348_BO1,204,203,200_.jpg" }
                );
            context.SaveChanges();

            context.MoviesData.AddOrUpdate(md => md.MovieId,
                new MovieData() { Name = "Back to the Future", Poster = "image.jpg", TCId = 1, MovieId = 1 },
                new MovieData() { Name = "Toy Story", Poster = "image.jpg", TCId = 1, MovieId = 2}
                );
            context.SaveChanges();
        }
    }
}
