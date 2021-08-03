namespace CrossStitchery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Floss", "InStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Floss", "InStock", c => c.Boolean(nullable: false));
        }
    }
}
