namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        NumberOfNegativeReviews = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionsWithoutAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        questions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.questions_Id)
                .Index(t => t.questions_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionsWithoutAnswers", "questions_Id", "dbo.Questions");
            DropIndex("dbo.QuestionsWithoutAnswers", new[] { "questions_Id" });
            DropTable("dbo.QuestionsWithoutAnswers");
            DropTable("dbo.Questions");
        }
    }
}
