namespace TravelProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acıklamalar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String());
        }
    }
}
