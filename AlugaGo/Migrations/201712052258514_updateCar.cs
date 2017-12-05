namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CategoryId", "dbo.CarCategories");
            DropIndex("dbo.Cars", new[] { "CategoryId" });
            DropColumn("dbo.Cars", "Direction");
            DropColumn("dbo.Cars", "Air");
            DropColumn("dbo.Cars", "EletricWindows");
            DropColumn("dbo.Cars", "SoundSystem");
            DropColumn("dbo.Cars", "Lock");
            DropColumn("dbo.Cars", "Alarm");
            DropColumn("dbo.Cars", "Airbag");
            DropColumn("dbo.Cars", "ABS");
            DropColumn("dbo.Cars", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "ABS", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Airbag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Alarm", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Lock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "SoundSystem", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "EletricWindows", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Air", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Direction", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Cars", "CategoryId");
            AddForeignKey("dbo.Cars", "CategoryId", "dbo.CarCategories", "Id", cascadeDelete: true);
        }
    }
}
