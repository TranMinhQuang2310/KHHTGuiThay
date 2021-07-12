namespace Demo_Login2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11072021V4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LopHocs", "IDAccount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LopHocs", "IDAccount", c => c.Int());
        }
    }
}
