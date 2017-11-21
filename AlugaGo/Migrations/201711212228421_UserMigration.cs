namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMigration : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0a2381d0-b905-4e7b-86a9-4f82a7e42b14', N'visitor@vidly.com', 0, N'AA3FR+Wo/95h6giCDOtsAp7CEw6SWRXWrKQ1KVgvrJnY0xhMnZkPB8DQql2+Zj/aWw==', N'28fecf94-3e7a-4612-8fc2-0c5ed5a666c2', NULL, 0, 0, NULL, 1, 0, N'visitor@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'50e341bd-28c5-4f97-994b-f63d54329a99', N'admin@vidly.com', 0, N'ABRk/s0VAfQ/mgWSkPkLuiEpzJVZqbLD7gmQju5xFJzpwsOY9C6/LrvjsVZl1xvzMg==', N'83b543e4-1668-47cc-ba0a-16282c0edd80', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'443c3a32-ff38-4e63-8b45-d109d514be2d', N'PodeGerenciarClientes')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'50e341bd-28c5-4f97-994b-f63d54329a99', N'443c3a32-ff38-4e63-8b45-d109d514be2d')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
