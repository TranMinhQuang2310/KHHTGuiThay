namespace Demo_Login2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11072021v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LopHocs", "Account_ID", "dbo.Accounts");
            DropIndex("dbo.LopHocs", new[] { "Account_ID" });
            DropColumn("dbo.LopHocs", "Account_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LopHocs", "Account_ID", c => c.Int());
            CreateIndex("dbo.LopHocs", "Account_ID");
            AddForeignKey("dbo.LopHocs", "Account_ID", "dbo.Accounts", "ID");
        }
    }
}
