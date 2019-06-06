namespace ProjZes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminAndEmployeeRoles : DbMigration
    {
        public override void Up()
        {
            // Create manager and employee roles
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'10b6fb29-189f-4cb2-9381-cb09ab8591ef', N'Employee')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a61842f6-7ba6-4c6f-8443-e58dbaae45ec', N'Manager')
            ");

            // Add admin user
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Address], [Points]) VALUES (N'2c302745-fa8f-4a6d-a50f-73af5ff08237', N'admin@expetropolandex.pl', 0, N'ACxUtt37c8iEcxD4b3NRUqXP5GPY/m9//8kllowCu+u/T620JoGOSG26mbLgQiS8EA==', N'f5372948-946b-4214-ad8e-52b732210407', N'0123456', 0, 0, NULL, 1, 0, N'admin@expetropolandex.pl', N'Jan', N'Kowalski', N'ul. Jana Paw³a II 37, 31-864 Kraków', 0)");

            // Assign admin user to the manager role
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2c302745-fa8f-4a6d-a50f-73af5ff08237', N'a61842f6-7ba6-4c6f-8443-e58dbaae45ec')");
        }
        
        public override void Down()
        {
        }
    }
}
