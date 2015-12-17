namespace Final_Capstone___PCTC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDatas",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Title = c.String(),
                        TCId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.TimeCapsules", t => t.TCId)
                .Index(t => t.TCId);
            
            CreateTable(
                "dbo.TimeCapsules",
                c => new
                    {
                        TCId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                        ChildImg = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.TCId)
                .ForeignKey("dbo.PCTCUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MovieDatas",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Poster = c.String(),
                        ConnectedMDToTC_TCId = c.Int(),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.TimeCapsules", t => t.ConnectedMDToTC_TCId)
                .Index(t => t.ConnectedMDToTC_TCId);
            
            CreateTable(
                "dbo.NoteDatas",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Link = c.String(),
                        Text = c.String(),
                        Title = c.String(),
                        ConnectedNDToTC_TCId = c.Int(),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.TimeCapsules", t => t.ConnectedNDToTC_TCId)
                .Index(t => t.ConnectedNDToTC_TCId);
            
            CreateTable(
                "dbo.SongDatas",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Album = c.String(),
                        Artist = c.String(),
                        Title = c.String(),
                        ConnectedSDToTC_TCId = c.Int(),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.TimeCapsules", t => t.ConnectedSDToTC_TCId)
                .Index(t => t.ConnectedSDToTC_TCId);
            
            CreateTable(
                "dbo.PCTCUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ChildId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                        Gender = c.String(),
                        Image = c.String(),
                        ConnectionChildToUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ChildId)
                .ForeignKey("dbo.PCTCUsers", t => t.ConnectionChildToUser_UserId)
                .Index(t => t.ConnectionChildToUser_UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BookDatas", "TCId", "dbo.TimeCapsules");
            DropForeignKey("dbo.TimeCapsules", "UserId", "dbo.PCTCUsers");
            DropForeignKey("dbo.Children", "ConnectionChildToUser_UserId", "dbo.PCTCUsers");
            DropForeignKey("dbo.SongDatas", "ConnectedSDToTC_TCId", "dbo.TimeCapsules");
            DropForeignKey("dbo.NoteDatas", "ConnectedNDToTC_TCId", "dbo.TimeCapsules");
            DropForeignKey("dbo.MovieDatas", "ConnectedMDToTC_TCId", "dbo.TimeCapsules");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Children", new[] { "ConnectionChildToUser_UserId" });
            DropIndex("dbo.SongDatas", new[] { "ConnectedSDToTC_TCId" });
            DropIndex("dbo.NoteDatas", new[] { "ConnectedNDToTC_TCId" });
            DropIndex("dbo.MovieDatas", new[] { "ConnectedMDToTC_TCId" });
            DropIndex("dbo.TimeCapsules", new[] { "UserId" });
            DropIndex("dbo.BookDatas", new[] { "TCId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Children");
            DropTable("dbo.PCTCUsers");
            DropTable("dbo.SongDatas");
            DropTable("dbo.NoteDatas");
            DropTable("dbo.MovieDatas");
            DropTable("dbo.TimeCapsules");
            DropTable("dbo.BookDatas");
        }
    }
}
