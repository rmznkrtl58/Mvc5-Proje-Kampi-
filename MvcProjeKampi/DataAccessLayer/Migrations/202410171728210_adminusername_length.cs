namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminusername_length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "UserName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Admins", "PassWord", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "PassWord", c => c.String(maxLength: 10));
            AlterColumn("dbo.Admins", "UserName", c => c.String(maxLength: 10));
        }
    }
}
