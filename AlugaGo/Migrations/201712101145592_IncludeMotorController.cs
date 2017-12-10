namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeMotorController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Motorcycles", "Fabricante", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Motorcycles", "CylinderCapacity", c => c.Int(nullable: false));
            AlterColumn("dbo.Motorcycles", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Motorcycles", "Name", c => c.String());
            DropColumn("dbo.Motorcycles", "CylinderCapacity");
            DropColumn("dbo.Motorcycles", "Fabricante");
        }
    }
}
