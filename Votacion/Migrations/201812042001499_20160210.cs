namespace Votacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20160210 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.States", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.States", "Description", c => c.String());
        }
    }
}
