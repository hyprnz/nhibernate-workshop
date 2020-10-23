using FluentMigrator;

namespace Shared.DataAccess.Migrations
{
    [Migration(20200907_200800)]
    public class M200200907_AddLogTable : UpOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Log")
               .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
               .WithColumn("Text").AsString();
        }
    }
}
