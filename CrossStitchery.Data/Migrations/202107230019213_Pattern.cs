namespace CrossStitchery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pattern : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pattern", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pattern", "Category", c => c.String(nullable: false));
        }
    }
}
