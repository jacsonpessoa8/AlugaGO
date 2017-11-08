namespace AlugaGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Cpf", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Cpf", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
