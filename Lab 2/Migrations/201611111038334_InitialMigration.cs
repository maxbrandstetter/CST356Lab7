namespace Lab_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                {
                    GroupId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.GroupId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 32),
                    LastName = c.String(nullable: false, maxLength: 32),
                    EmailAddress = c.String(nullable: false, maxLength: 64),
                    NumberOfSiblings = c.String(nullable: false),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.UserId);
            
                CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Group_GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Group_GroupId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Group_GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGroups", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserGroups", new[] { "Group_GroupId" });
            DropIndex("dbo.UserGroups", new[] { "User_UserId" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.Users");
            DropTable("dbo.Groups");
        }
    }
}
