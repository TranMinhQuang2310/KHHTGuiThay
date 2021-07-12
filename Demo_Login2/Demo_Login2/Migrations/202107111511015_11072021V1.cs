namespace Demo_Login2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11072021V1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "IDLopHoc", "dbo.LopHocs");
            AddColumn("dbo.Accounts", "LopHoc_ID", c => c.Int());
            AddColumn("dbo.LopHocs", "Account_ID", c => c.Int());
            CreateIndex("dbo.Accounts", "LopHoc_ID");
            CreateIndex("dbo.LopHocs", "IDAccount");
            CreateIndex("dbo.LopHocs", "Account_ID");
            AddForeignKey("dbo.LopHocs", "IDAccount", "dbo.Accounts", "ID");
            AddForeignKey("dbo.LopHocs", "Account_ID", "dbo.Accounts", "ID");
            AddForeignKey("dbo.Accounts", "LopHoc_ID", "dbo.LopHocs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "LopHoc_ID", "dbo.LopHocs");
            DropForeignKey("dbo.LopHocs", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.LopHocs", "IDAccount", "dbo.Accounts");
            DropIndex("dbo.LopHocs", new[] { "Account_ID" });
            DropIndex("dbo.LopHocs", new[] { "IDAccount" });
            DropIndex("dbo.Accounts", new[] { "LopHoc_ID" });
            DropColumn("dbo.LopHocs", "Account_ID");
            DropColumn("dbo.Accounts", "LopHoc_ID");
            AddForeignKey("dbo.Accounts", "IDLopHoc", "dbo.LopHocs", "ID");
        }
    }
}
