using FluentMigrator;

namespace Shared.DataAccess.Migrations
{
    [Migration(20200907_200800)]
    public class M200200907_AddLogTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Log");
        }

        public override void Up()
        {
            Create.Table("Log")
               .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
               .WithColumn("Text").AsString();
        }
    }
}
