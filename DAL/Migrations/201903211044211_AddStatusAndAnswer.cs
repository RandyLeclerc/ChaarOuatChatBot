namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusAndAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Answer", c => c.String());
            AddColumn("dbo.Questions", "Status", c => c.String());
            DropColumn("dbo.Questions", "NumberOfNegativeReviews");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "NumberOfNegativeReviews", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "Status");
            DropColumn("dbo.Questions", "Answer");
        }
    }
}
