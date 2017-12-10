namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Motorcycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Motorcycles", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Motorcycles", new[] { "Category_Id" });
            DropTable("dbo.Motorcycles");
        }
    }
}
