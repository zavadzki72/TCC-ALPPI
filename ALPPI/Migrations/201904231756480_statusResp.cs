namespace ALPPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusResp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resposta", "isEnviado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resposta", "isEnviado");
        }
    }
}
