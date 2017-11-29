namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarCharacteristics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Door", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Image", c => c.String());
            AddColumn("dbo.Cars", "Direction", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Air", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "EletricWindows", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "SoundSystem", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Lock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Alarm", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Airbag", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "ABS", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "ABS");
            DropColumn("dbo.Cars", "Airbag");
            DropColumn("dbo.Cars", "Alarm");
            DropColumn("dbo.Cars", "Lock");
            DropColumn("dbo.Cars", "SoundSystem");
            DropColumn("dbo.Cars", "EletricWindows");
            DropColumn("dbo.Cars", "Air");
            DropColumn("dbo.Cars", "Direction");
            DropColumn("dbo.Cars", "Image");
            DropColumn("dbo.Cars", "Door");
        }
    }
}
