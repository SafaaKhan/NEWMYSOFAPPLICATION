namespace NEWMYSOFAPPLICATION.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NormalTransactions", "phrase", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NormalTransactions", "phrase");
        }
    }
}
