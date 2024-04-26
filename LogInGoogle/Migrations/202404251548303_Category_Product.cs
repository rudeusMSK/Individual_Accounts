namespace LogInGoogle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category_Product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb1_Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        IsActive = c.Boolean(nullable: false, defaultValue: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tb1_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Price = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false, defaultValue: true),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb1_Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb1_Product", "CategoryId", "dbo.Tb1_Category");
            DropIndex("dbo.Tb1_Product", new[] { "CategoryId" });
            DropTable("dbo.Tb1_Product");
            DropTable("dbo.Tb1_Category");
        }
    }
}
