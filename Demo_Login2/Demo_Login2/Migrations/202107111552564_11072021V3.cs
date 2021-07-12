namespace Demo_Login2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11072021V3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LopHocs", "IDAccount", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "LopHoc_ID", "dbo.LopHocs");
            DropForeignKey("dbo.Accounts", "IDLopHoc", "dbo.LopHocs");
            DropIndex("dbo.Accounts", new[] { "IDLopHoc" });
            DropIndex("dbo.Accounts", new[] { "LopHoc_ID" });
            DropIndex("dbo.LopHocs", new[] { "IDAccount" });
            CreateTable(
                "dbo.AccountLopHocs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDLopHoc = c.Int(),
                        IDAccount = c.Int(),
                        IsDisabled = c.Boolean(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.IDAccount)
                .ForeignKey("dbo.LopHocs", t => t.IDLopHoc)
                .Index(t => t.IDLopHoc)
                .Index(t => t.IDAccount);
            
            DropColumn("dbo.Accounts", "IDLopHoc");
            DropColumn("dbo.Accounts", "IDCNLSV");
            DropColumn("dbo.Accounts", "LopHoc_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "LopHoc_ID", c => c.Int());
            AddColumn("dbo.Accounts", "IDCNLSV", c => c.Int());
            AddColumn("dbo.Accounts", "IDLopHoc", c => c.Int());
            DropForeignKey("dbo.AccountLopHocs", "IDLopHoc", "dbo.LopHocs");
            DropForeignKey("dbo.AccountLopHocs", "IDAccount", "dbo.Accounts");
            DropIndex("dbo.AccountLopHocs", new[] { "IDAccount" });
            DropIndex("dbo.AccountLopHocs", new[] { "IDLopHoc" });
            DropTable("dbo.AccountLopHocs");
            CreateIndex("dbo.LopHocs", "IDAccount");
            CreateIndex("dbo.Accounts", "LopHoc_ID");
            CreateIndex("dbo.Accounts", "IDLopHoc");
            AddForeignKey("dbo.Accounts", "IDLopHoc", "dbo.LopHocs", "ID");
            AddForeignKey("dbo.Accounts", "LopHoc_ID", "dbo.LopHocs", "ID");
            AddForeignKey("dbo.LopHocs", "IDAccount", "dbo.Accounts", "ID");
        }
    }
}
