namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migri05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Category_Id", "dbo.CarCategories");
            DropIndex("dbo.Cars", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Cars", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Cars", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "CategoryId");
            AddForeignKey("dbo.Cars", "CategoryId", "dbo.CarCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CategoryId", "dbo.CarCategories");
            DropIndex("dbo.Cars", new[] { "CategoryId" });
            AlterColumn("dbo.Cars", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Cars", "Category_Id");
            AddForeignKey("dbo.Cars", "Category_Id", "dbo.CarCategories", "Id");
        }
    }
}
