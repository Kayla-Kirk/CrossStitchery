namespace CrossStitchery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFiles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pattern", "AidaCount", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber2", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber3", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber4", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber5", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber6", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber7", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber8", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber9", c => c.Int(nullable: false));
            AddColumn("dbo.Pattern", "ColorNumber10", c => c.Int(nullable: false));
            AlterColumn("dbo.Floss", "BobbinAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Floss", "BobbinAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Pattern", "ColorNumber10");
            DropColumn("dbo.Pattern", "ColorNumber9");
            DropColumn("dbo.Pattern", "ColorNumber8");
            DropColumn("dbo.Pattern", "ColorNumber7");
            DropColumn("dbo.Pattern", "ColorNumber6");
            DropColumn("dbo.Pattern", "ColorNumber5");
            DropColumn("dbo.Pattern", "ColorNumber4");
            DropColumn("dbo.Pattern", "ColorNumber3");
            DropColumn("dbo.Pattern", "ColorNumber2");
            DropColumn("dbo.Pattern", "ColorNumber");
            DropColumn("dbo.Pattern", "AidaCount");
        }
    }
}
