namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionsWithoutAnswers", "questions_Id", "dbo.Questions");
            DropIndex("dbo.QuestionsWithoutAnswers", new[] { "questions_Id" });
            DropTable("dbo.QuestionsWithoutAnswers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestionsWithoutAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        questions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.QuestionsWithoutAnswers", "questions_Id");
            AddForeignKey("dbo.QuestionsWithoutAnswers", "questions_Id", "dbo.Questions", "Id");
        }
    }
}
