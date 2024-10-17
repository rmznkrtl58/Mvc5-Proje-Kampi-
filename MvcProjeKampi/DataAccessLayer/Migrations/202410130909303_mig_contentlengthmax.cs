namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contentlengthmax : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "ContentText", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "ContentText", c => c.String(maxLength: 1000));
        }
    }
}
