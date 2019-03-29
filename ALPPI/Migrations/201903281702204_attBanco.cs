namespace ALPPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attBanco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resposta", "nota", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resposta", "nota");
        }
    }
}
