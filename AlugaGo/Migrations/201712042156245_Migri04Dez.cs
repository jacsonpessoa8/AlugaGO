namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migri04Dez : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "Category_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Category_Id");
            AddForeignKey("dbo.Cars", "Category_Id", "dbo.CarCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Category_Id", "dbo.CarCategories");
            DropIndex("dbo.Cars", new[] { "Category_Id" });
            DropColumn("dbo.Cars", "Category_Id");
            DropTable("dbo.CarCategories");
        }
    }
}
