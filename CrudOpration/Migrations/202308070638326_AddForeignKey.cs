namespace CrudOpration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CategoryId_CategoryId", c => c.Int());
            CreateIndex("dbo.Products", "CategoryId_CategoryId");
            AddForeignKey("dbo.Products", "CategoryId_CategoryId", "dbo.Categories", "CategoryId");
            DropColumn("dbo.Products", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "CategoryId_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId_CategoryId" });
            DropColumn("dbo.Products", "CategoryId_CategoryId");
        }
    }
}
