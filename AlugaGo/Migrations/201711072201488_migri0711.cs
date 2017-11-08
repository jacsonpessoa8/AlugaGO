namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migri0711 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Cars", "Fabricante", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Fabricante", c => c.String());
            AlterColumn("dbo.Cars", "Name", c => c.String());
        }
    }
}
