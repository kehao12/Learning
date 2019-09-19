namespace Learning.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseCategories", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.CourseCategories", "Alias", c => c.String(nullable: false, maxLength: 256, unicode: false));
            AlterColumn("dbo.CourseCategories", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseCategories", "Description", c => c.String());
            AlterColumn("dbo.CourseCategories", "Alias", c => c.String());
            AlterColumn("dbo.CourseCategories", "Name", c => c.String());
        }
    }
}
