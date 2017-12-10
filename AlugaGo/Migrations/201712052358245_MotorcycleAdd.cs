namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MotorcycleAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "Category_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Category_Id");
            AddForeignKey("dbo.Cars", "Category_Id", "dbo.Categories", "Id");
            DropTable("dbo.CarCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Cars", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Cars", new[] { "Category_Id" });
            DropColumn("dbo.Cars", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
