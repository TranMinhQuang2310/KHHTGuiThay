namespace Demo_Login2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11072021V5 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Accounts", "IDKhoaDaoTao");
            AddForeignKey("dbo.Accounts", "IDKhoaDaoTao", "dbo.KhoaDaoTaos", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "IDKhoaDaoTao", "dbo.KhoaDaoTaos");
            DropIndex("dbo.Accounts", new[] { "IDKhoaDaoTao" });
        }
    }
}
