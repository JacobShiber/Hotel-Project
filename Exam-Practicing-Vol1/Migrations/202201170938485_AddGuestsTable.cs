namespace Exam_Practicing_Vol1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGuestsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuestModels");
        }
    }
}
