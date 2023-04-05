namespace TravelProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acıklamaguncelleme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Aciklama", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Aciklama", c => c.String(nullable: false, maxLength: 950));
        }
    }
}
