namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWriterStatusNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterStatus", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterStatus", c => c.String(maxLength: 50));
        }
    }
}
