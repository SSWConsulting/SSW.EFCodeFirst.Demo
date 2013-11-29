namespace EFCodeFirstDemo.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostcodeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Postcode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Postcode", c => c.Int(nullable: false));
        }
    }
}
